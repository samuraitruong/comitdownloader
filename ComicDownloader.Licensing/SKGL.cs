using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//Copyright (C) 2011-2012 Artem Los, www.clizware.net.
//The author of this code shall get the credits

// This project uses two general algorithms:
//  - Artem's Information Storage Format (Artem's ISF-2)
//  - Artem's Serial Key Algorithm (Artem's SKA-2)

// This project is also using an open source project, MegaMath
// that you might find here: http://megamath.sourceforge.net/
// MegaMath is license under the terms of th MIT License.

using System.Text;
using System.Management;
using System.Security;


[assembly: AllowPartiallyTrustedCallers()]
#region "S E R I A L  K E Y  G E N E R A T I N G  L I B R A R Y"

#region "CONFIGURATION"
public abstract class BaseConfiguration
{
    //Put all functions/variables that should be shared with
    //all other classes that inherit this class.
    //
    //note, this class cannot be used as a normal class that
    //you define because it is MustInherit.

    protected internal string _key = "";
    /// <summary>
    /// The key will be stored here
    /// </summary>
    public virtual string Key
    {
        //will be changed in both generating and validating classe.
        get { return _key; }
        set { _key = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public virtual string MachineCode
    {

        get { return getMachineCode(); }
    }


    private  string getMachineCode()
    {
        //      * Copyright (C) 2012 Artem Los, All rights reserved.
        //      * 
        //      * This code will generate a 5 digits long key, finger print, of the system
        //      * where this method is being executed. However, that might be changed in the
        //      * hash function "GetStableHash", by changing the amount of zeroes in
        //      * MUST_BE_LESS_OR_EQUAL_TO to the one you want to have. Ex 1000 will return 
        //      * 3 digits long hash.
        //      * 
        //      * Please note, that you might also adjust the order of these, but remember to
        //      * keep them there because as it is stated at 
        //      * (http://www.codeproject.com/Articles/17973/How-To-Get-Hardware-Information-CPU-ID-MainBoard-I)
        //      * the processorID might be the same at some machines, which will generate same
        //      * hashes for several machines.
        //      * 
        //      * The function will probably be implemented into SKGL Project at http://skgl.codeplex.com/
        //      * and Software Protector at http://softwareprotector.codeplex.com/, so I 
        //      * release this code under the same terms and conditions as stated here:
        //      * http://skgl.codeplex.com/license
        //      * 
        //      * Any questions, please contact me at
        //      *  * artem@artemlos.net
        //      
        methods m = new methods();

        ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");
        string collectedInfo = "";
        // here we will put the informa
        foreach (ManagementObject share in searcher.Get())
        {
            // first of all, the processorid
            collectedInfo += share["ProcessorId"];
        }

        searcher.Query = new ObjectQuery("select * from Win32_BIOS");
        foreach (ManagementObject share in searcher.Get())
        {
            //then, the serial number of BIOS
            collectedInfo += share["SerialNumber"];
        }

        searcher.Query = new ObjectQuery("select * from Win32_BaseBoard");
        foreach (ManagementObject share in searcher.Get())
        {
            //finally, the serial number of motherboard
            collectedInfo += share["SerialNumber"];
        }

        // patch luca bernardini
        if (string.IsNullOrEmpty(collectedInfo) | collectedInfo == "00" | collectedInfo.Length <= 3)
        {
            collectedInfo += getHddSerialNumber();
        }

        return m.getEightByteHash(collectedInfo, 100000).ToString();
    }

    // <summary>
    // Read the serial number from the hard disk that keep the bootable partition (boot disk)
    // </summary>
    // <returns>
    // If succedes, returns the string rappresenting the Serial Number.
    // String.Empty if it fails.
    // </returns>
    private static string getHddSerialNumber()
    {


        // --- Win32 Disk 
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("\\root\\cimv2", "select * from Win32_DiskPartition WHERE BootPartition=True");

        uint diskIndex = 999;
        foreach (ManagementObject partition in searcher.Get())
        {
            diskIndex = Convert.ToUInt32(partition["Index"]);
            break; // TODO: might not be correct. Was : Exit For
        }

        // I haven't found the bootable partition. Fail.
        if (diskIndex == 999)
            return string.Empty;



        // --- Win32 Disk Drive
        searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where Index = " + diskIndex.ToString());

        string deviceName = "";
        foreach (ManagementObject wmi_HD in searcher.Get())
        {
            deviceName = wmi_HD["Name"].ToString();
            break; // TODO: might not be correct. Was : Exit For
        }


        // I haven't found the disk drive. Fail
        if (string.IsNullOrEmpty(deviceName.Trim()))
            return string.Empty;

        // -- Some problems in query parsing with backslash. Using like operator
        if (deviceName.StartsWith("\\\\.\\"))
        {
            deviceName = deviceName.Replace("\\\\.\\", "%");
        }


        // --- Physical Media
        searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia WHERE Tag like '" + deviceName + "'");
        string serial = string.Empty;
        foreach (ManagementObject wmi_HD in searcher.Get())
        {
            serial = wmi_HD["SerialNumber"].ToString();
            break; // TODO: might not be correct. Was : Exit For
        }

        return serial;

    }

}
public class SerialKeyConfiguration : BaseConfiguration
{

    #region "V A R I A B L E S"
    private int[] _admBlock = new int[1] { 1 };
    public int[] admBlock
    {
        get { return _admBlock; }
        set { _admBlock = value; }
    }
    private bool[] _Features = new bool[8] {
		false,
		false,
		false,
		false,
		false,
		false,
		false,
		false
		//the default value of the Fetures array.
	};
    public virtual bool[] Features
    {
        //will be changed in validating class.
        get { return _Features; }
        set { _Features = value; }
    }
    private bool _addSplitChar = true;
    public bool addSplitChar
    {
        get { return _addSplitChar; }
        set { _addSplitChar = value; }
    }


    #endregion

}
#endregion

#region "ENCRYPTION"
public class Generate : BaseConfiguration
{
    //this class have to be inherited because of the key which is shared with both encryption/decryption classes.

    SerialKeyConfiguration skc = new SerialKeyConfiguration();
    methods m = new methods();
    Random r = new Random();
    public Generate()
    {
        // No overloads works with Sub New
    }
    public Generate(SerialKeyConfiguration _serialKeyConfiguration)
    {
        skc = _serialKeyConfiguration;
    }

    private string _secretPhase;
    /// <summary>
    /// If the key is to be encrypted, enter a password here.
    /// </summary>

    public string secretPhase
    {
        get { return _secretPhase; }
        set
        {
            if (value != _secretPhase)
            {
                _secretPhase = m.twentyfiveByteHash(value);
            }
        }
    }
    /// <summary>
    /// This function will generate a key.
    /// </summary>
    /// <param name="timeLeft">For instance, 30 days.</param>
    public string doKey(int timeLeft)
    {
        return doKey(timeLeft, DateTime.Now, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeLeft">For instance, 30 days</param>
    /// <param name="useMachineCode">Lock a serial key to a specific machine, given its "machine code". Should be 5 digits long.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public object doKey(int timeLeft, int useMachineCode)
    {
        return doKey(timeLeft, DateTime.Now, useMachineCode);
    }

    /// <summary>
    /// This function will generate a key. You may also change the creation date.
    /// </summary>
    /// <param name="timeLeft">For instance, 30 days.</param>
    /// <param name="creationDate">Change the creation date of a key.</param>
    /// <param name="useMachineCode">Lock a serial key to a specific machine, given its "machine code". Should be 5 digits long.</param>
    public string doKey(int timeLeft, System.DateTime creationDate, int useMachineCode = 0)
    {
        if (timeLeft > 999)
        {
            //Checking if the timeleft is NOT larger than 999. It cannot be larger to match the key-length 20.
            throw new ArgumentException("The timeLeft is larger than 999. It can only consist of three digits.");
        }

        if (!string.IsNullOrEmpty(secretPhase) | secretPhase != null)
        {
            //if some kind of value is assigned to the variable "secretPhase", the code will execute it FIRST.
            //the secretPhase shall only consist of digits!
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^\\d$");
            //cheking the string
            if (reg.IsMatch(secretPhase))
            {
                //throwing new exception if the string contains non-numrical letters.
                throw new ArgumentException("The secretPhase consist of non-numerical letters.");
            }
        }

        //if no exception is thown, do following
        string _stageThree = null;
        if (useMachineCode > 0 & useMachineCode <= 99999)
        {
            _stageThree = m._encrypt(timeLeft, skc.Features, secretPhase, useMachineCode, creationDate);
            // stage one
        }
        else
        {
            _stageThree = m._encrypt(timeLeft, skc.Features, secretPhase, r.Next(0, 99999), creationDate);
            // stage one
        }

        //if it is the same value as default, we do not need to mix chars. This step saves generation time.

        if (skc.admBlock.Count == 20)
        {
            if (skc.addSplitChar == true)
            {
                // by default, a split character will be added
                Key = m.setMixChars(_stageThree.ToCharArray(), skc.admBlock);
                _stageThree = Key.Substring(0, 5) + "-" + Key.Substring(5, 5) + "-" + Key.Substring(10, 5) + "-" + Key.Substring(15, 5);
                Key = _stageThree;
                return Key;
            }
            else
            {
                //we also include the key in the Key variable to make it possible for user to get his key without generating a new one.
                Key = m.setMixChars(_stageThree, skc.admBlock);
                return Key;
            }
        }
        else
        {
            if (skc.addSplitChar == true)
            {
                // by default, a split character will be addedr
                Key = _stageThree.Substring(0, 5) + "-" + _stageThree.Substring(5, 5) + "-" + _stageThree.Substring(10, 5) + "-" + _stageThree.Substring(15, 5);
            }
            else
            {
                Key = _stageThree;
            }

            //we also include the key in the Key variable to make it possible for user to get his key without generating a new one.
            return Key;

        }

    }
}
#endregion

#region "DECRYPTION"
public class Validate : BaseConfiguration
{
    //this class have to be inherited becuase of the key which is shared with both encryption/decryption classes.

    SerialKeyConfiguration skc = new SerialKeyConfiguration();
    methods _a = new methods();
    public Validate()
    {
        // No overloads works with Sub New
    }
    public Validate(SerialKeyConfiguration _serialKeyConfiguration)
    {
        skc = _serialKeyConfiguration;
    }
    /// <summary>
    /// Enter a key here before validating.
    /// </summary>
    public string Key
    {
        //re-defining the Key
        get { return _key; }
        set
        {
            _res = "";
            _key = value;
        }
    }

    private string _secretPhase = "";
    /// <summary>
    /// If the key has been encrypted, when it was generated, please set the same secretPhase here.
    /// </summary>
    public string secretPhase
    {
        get { return _secretPhase; }
        set
        {
            if (value != _secretPhase)
            {
                _secretPhase = _a.twentyfiveByteHash(value);
            }
        }
    }


    private string _res = "";

    private void decodeKeyToString()
    {
        // checking if the key already have been decoded.
        if (string.IsNullOrEmpty(_res) | _res == null)
        {

            string _stageOne = "";

            Key = Key.Replace("-", "");

            //if the admBlock has been changed, the getMixChars will be executed.

            if (skc.admBlock.Count == 20)
            {
                _stageOne = _a.getMixChars(Key, skc.admBlock);

            }
            else
            {
                _stageOne = Key;
            }

            _stageOne = Key;

            // _stageTwo = _a._decode(_stageOne)

            if (!string.IsNullOrEmpty(secretPhase) | secretPhase != null)
            {
                //if no value "secretPhase" given, the code will directly decrypt without using somekind of encryption
                //if some kind of value is assigned to the variable "secretPhase", the code will execute it FIRST.
                //the secretPhase shall only consist of digits!
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^\\d$");
                //cheking the string
                if (reg.IsMatch(secretPhase))
                {
                    //throwing new exception if the string contains non-numrical letters.
                    throw new ArgumentException("The secretPhase consist of non-numerical letters.");
                }
            }
            _res = _a._decrypt(_stageOne, secretPhase);


        }
    }
    private bool _IsValid()
    {
        //Dim _a As New methods ' is only here to provide the geteighthashcode method
        try
        {
            if (Key.Contains("-"))
            {
                if (Key.Length != 23)
                {
                    return false;
                }
            }
            else
            {
                if (Key.Length != 20)
                {
                    return false;
                }
            }
            decodeKeyToString();

            string _decodedHash = _res.Substring(0, 9);
            string _calculatedHash = _a.getEightByteHash(_res.Substring(9, 19)).ToString().Substring(0, 9);
            // changed Math.Abs(_res.Substring(0, 17).GetHashCode).ToString.Substring(0, 8)

            //When the hashcode is calculated, it cannot be taken for sure, 
            //that the same hash value will be generated.
            //learn more about this issue: http://msdn.microsoft.com/en-us/library/system.object.gethashcode.aspx
            if (_decodedHash == _calculatedHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            //if something goes wrong, for example, when decrypting, 
            //this function will return false, so that user knows that it is unvalid.
            //if the key is valid, there won't be any errors.
            return false;
        }
    }
    /// <summary>
    /// Checks whether the key has been modified or not. If the key has been modified - returns false; if the key has not been modified - returns true.
    /// </summary>
    public bool IsValid
    {
        get { return _IsValid(); }
    }
    private bool _IsExpired()
    {
        if (DaysLeft > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// If the key has expired - returns true; if the key has not expired - returns false.
    /// </summary>
    public bool IsExpired
    {
        get { return _IsExpired(); }
    }
    private System.DateTime _CreationDay()
    {
        decodeKeyToString();
        System.DateTime _date = new System.DateTime();
        _date = _res.Substring(9, 4) + "-" + _res.Substring(13, 2) + "-" + _res.Substring(15, 2);

        return _date;
    }
    /// <summary>
    /// Returns the creation date of the key.
    /// </summary>
    public System.DateTime CreationDate
    {
        get { return _CreationDay(); }
    }
    private int _DaysLeft()
    {
        decodeKeyToString();
        int _setDays = SetTime;
        return DateAndTime.DateDiff(DateInterval.DayOfYear, DateAndTime.Today, ExpireDate);
    }
    /// <summary>
    /// Returns the amount of days the key will be valid.
    /// </summary>
    public int DaysLeft
    {
        get { return _DaysLeft(); }
    }

    private int _SetTime()
    {
        decodeKeyToString();
        return _res.Substring(17, 3);
    }
    /// <summary>
    /// Returns the actual amount of days that were set when the key was generated.
    /// </summary>
    public int SetTime
    {
        get { return _SetTime(); }
    }
    private System.DateTime _ExpireDate()
    {
        decodeKeyToString();
        System.DateTime _date = new System.DateTime();
        _date = CreationDate;
        return _date.AddDays(SetTime);
    }
    /// <summary>
    /// Returns the date when the key is to be expired.
    /// </summary>
    public System.DateTime ExpireDate
    {
        get { return _ExpireDate(); }
    }
    private bool[] _Features()
    {
        decodeKeyToString();
        return _a.intToBoolean(_res.Substring(20, 3));
    }
    /// <summary>
    /// Returns all 8 features in a boolean array
    /// </summary>
    public bool[] Features
    {
        //we already have defined Features in the BaseConfiguration class. 
        //Here we only change it to Read Only.
        get { return _Features(); }
    }

    /// <summary>
    /// If the current machine's machine code is equal to the one that this key is designed for, return true.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public bool IsOnRightMachine
    {
        get
        {
            int decodedMachineCode = Convert.ToInt32(_res.Substring(23, 5));

            return decodedMachineCode.ToString() == MachineCode;
        }
    }
}
#endregion

#region "T H E  C O R E  O F  S K G L"

internal class methods : SerialKeyConfiguration
{

    //The construction of the key
    protected internal string _encrypt(int _days, bool[] _tfg, string _secretPhase, int ID, System.DateTime _creationDate)
    {
        // This function will store information in Artem's ISF-2
        //Random variable was moved because of the same key generation at the same time.

        int _retInt = _creationDate.ToString("yyyyMMdd");
        // today

        decimal result = 0;

        result += _retInt;
        // adding the current date; the generation date; today.
        result *= 1000;
        // shifting three times at left

        result += _days;
        // adding time left
        result *= 1000;
        // shifting three times at left

        result += booleanToInt(_tfg);
        // adding features
        result *= 100000;
        //shifting three times at left

        result += ID;
        // adding random ID

        // This part of the function uses Artem's SKA-2

        if (string.IsNullOrEmpty(_secretPhase) | _secretPhase == null)
        {
            // if not password is set, return an unencrypted key
            return base10ToBase26(getEightByteHash(result) + result);
        }
        else
        {
            // if password is set, return an encrypted 
            return base10ToBase26(getEightByteHash(result) + _encText(result.ToString(), _secretPhase));
        }


    }
    protected internal string _decrypt(string _key, string _secretPhase)
    {
        if (string.IsNullOrEmpty(_secretPhase) | _secretPhase == null)
        {
            // if not password is set, return an unencrypted key
            return base26ToBase10(_key);
        }
        else
        {
            // if password is set, return an encrypted 
            string usefulInformation = base26ToBase10(_key);
            return usefulInformation.Substring(0, 9) + _decText(usefulInformation.Substring(9), _secretPhase);
        }

    }
    //Deeper - encoding, decoding, et cetera.

    //Convertions, et cetera.----------------
    protected internal object setMixChars(char[] _text, int[] _admBlock)
    {
        string _newText = "";
        for (int i = 0; i <= _text.Length - 1; i++)
        {
            _newText += _text[_admBlock[i]];
        }
        return _newText;
    }
    protected internal object getMixChars(char[] _text, int[] _admBlock)
    {
        string _newText = "";
        for (int i = 0; i <= _text.Length - 1; i++)
        {
            _newText += _text[new ArrayList(_admBlock).IndexOf(i)];
        }
        return _newText;
    }
    protected internal int booleanToInt(bool[] _booleanArray)
    {
        int _aVector = 0;
        //
        //In this function we are converting a binary value array to a int
        //A binary array can max contain 4 values.
        //Ex: new boolean(){1,1,1,1}

        for (int _i = 0; _i <= _booleanArray.Length - 1; _i++)
        {
            switch (_booleanArray[_i])
            {
                case -1:
                    _aVector += (Math.Pow(2, (_booleanArray.Length - _i - 1)));
                    // times 1 has been removed
                    break;
            }
        }
        return _aVector;
    }
    protected internal bool[] intToBoolean(int _num)
    {
        //In this function we are converting an integer (created with privious function) to a binary array

        int _bReturn = Convert.ToString(_num, 2);
        string _aReturn = Return_Lenght(_bReturn, 8);
        bool[] _cReturn = new bool[8];


        for (int i = 0; i <= 7; i++)
        {
            _cReturn[i] = _aReturn.ToString().Substring(i, 1);
        }
        return _cReturn;
    }
    protected internal string _encText(string _inputPhase, string _secretPhase)
    {
        //in this class we are encrypting the integer array.
        string _res = null;

        for (int i = 0; i <= _inputPhase.Length - 1; i++)
        {
            _res += modulo(_inputPhase.Substring(i, 1) + +_secretPhase.Substring(modulo(i, _secretPhase.Length), 1), 10);
        }

        return _res;
    }
    protected internal string _decText(string _encryptedPhase, string _secretPhase)
    {
        //in this class we are decrypting the text encrypted with the function above.
        string _res = null;

        for (int i = 0; i <= _encryptedPhase.Length - 1; i++)
        {
            _res += modulo(_encryptedPhase.Substring(i, 1) - _secretPhase.Substring(modulo(i, _secretPhase.Length), 1), 10);
        }

        return _res;
    }
    protected internal string Return_Lenght(string Number, int Lenght)
    {
        // This function create 3 lenght char ex: 39 to 039
        if ((Number.ToString().Length != Lenght))
        {
            while (!(Number.ToString().Length == Lenght))
            {
                Number = "0" + Number;
            }
        }
        return Number;
        //Return Number

    }
    protected internal int modulo(int _num, int _base)
    {
        // canged return type to integer.
        //this function simply calculates the "right modulo".
        //by using this function, there won't, hopefully be a negative
        //number in the result!
        return _num - _base * Convert.ToInt32(_num / _base);
    }
    protected internal string twentyfiveByteHash(string s)
    {
        int amountOfBlocks = s.Length / 5;
        string[] preHash = new string[amountOfBlocks + 1];

        if (s.Length <= 5)
        {
            //if the input string is shorter than 5, no need of blocks! 
            preHash[0] = getEightByteHash(s).ToString();
        }
        else if (s.Length > 5)
        {
            //if the input is more than 5, there is a need of dividing it into blocks.
            for (int i = 0; i <= amountOfBlocks - 2; i++)
            {
                preHash[i] = getEightByteHash(s.Substring(i * 5, 5)).ToString();
            }

            preHash[preHash.Length - 2] = getEightByteHash(s.Substring((preHash.Length - 2) * 5, s.Length - (preHash.Length - 2) * 5)).ToString();
        }
        return string.Join("", preHash);
    }
    protected internal int getEightByteHash(string s, int MUST_BE_LESS_THAN = 1000000000)
    {
        //This function generates a eight byte hash

        //The length of the result might be changed to any length
        //just set the amount of zeroes in MUST_BE_LESS_THAN
        //to any length you want

        uint hash = 0;

        foreach (byte b in System.Text.Encoding.Unicode.GetBytes(s))
        {
            hash += b;
            hash += (hash << 10);
            hash = hash ^ (hash >> 6);
        }

        hash += (hash << 3);
        hash = hash ^ (hash >> 11);
        hash += (hash << 15);

        uint result = hash % MUST_BE_LESS_THAN;
        int check = Conversion.Fix(MUST_BE_LESS_THAN / result);

        if (check > 1)
        {
            //checking so that all results are of the same size
            result *= check;
        }

        return result;
    }
    protected internal string base10ToBase26(decimal s)
    {
        // This method is converting a base 10 number to base 26 number.
        // Remember that s is a decimal, and the size is limited. 
        // In order to get size, type Decimal.MaxValue.
        //
        // Note that this method will still work, even though you only 
        // can add, subtract numbers in range of 15 digits.
        char[] allowedLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        decimal num = s;
        int reminder = 0;

        char[] result = new char[s.ToString().Length + 1];
        int j = 0;


        while ((num >= 26))
        {
            reminder = num % 26;
            result[j] = allowedLetters[reminder];
            num = (num - reminder) / 26;
            j += 1;
        }

        result[j] = allowedLetters[num];
        // final calculation

        string returnNum = "";
        for (int k = j; k >= k < 0; k += -1)
        {
            returnNum += result[k];
        }
        return returnNum;

    }
    protected internal decimal base26ToBase10(string s)
    {
        // This function will convert a number that has been generated
        // with functin above, and get the actual number in decimal
        //
        // This function requieres Mega Math to work correctly.

        string allowedLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        decimal result = default(decimal);


        for (int i = 0; i <= s.Length - 1; i += 1)
        {
            string pow = powof("26", (s.Length - i - 1).ToString()).ToString();

            result = MegaMath.MegaIntegerAddition( result,  MegaMath.MegaIntgerMultiply( allowedLetters.IndexOf(s.Substring(i, 1)).ToString(),  pow));

        }

        return result;
    }

    protected internal string powof(string x, string y)
    {
        // Because of the uncertain answer using Math.Pow and ^, 
        // this function is here to solve that issue.
        // It is currently using the MegaMath library to calculate.
        string newNum = 1;
        MegaMath megacalc = new MegaMath();

        if (y == "0")
        {
            return 1;
            // if 0, return 1, e.g. x^0 = 1 (mathematicaly proven!) 
        }
        else if (y == "1")
        {
            return x;
            // if 1, return x, which is the base, e.g. x^1 = x
        }
        else
        {
            for (int i = 0; i <= y - 1; i++)
            {
                newNum = MegaMath.MegaIntgerMultiply( newNum.ToString(),  x);
            }
            return newNum;
            // if both conditions are not satisfied, this loop
            // will continue to y, which is the exponent.
        }
    }
}


#endregion

#region "MEGA MATH"

internal class MegaMath
{


    public Exception ex_args = new Exception("Invalid parameter");
    #region "Integer Functions"

    /// <summary>
    /// Divide one large integer by another
    /// </summary>
    /// <param name="value">Number</param>
    /// <param name="divisor">Divisor</param>
    /// <param name="sModulus">Pass a string to this parameter to receive the remainder</param>
    /// <returns>Signed integer</returns>
    /// <remarks></remarks>
    public static string MegaIntegerDivide( string value,  string divisor,  string sModulus)
    {
        bool bNegative = false;

        if (isPositive( value) && isNegative( divisor))
        {
            bNegative = true;
        }
        else if (isNegative( value) && isPositive( divisor))
        {
            bNegative = true;
        }

        if (value == divisor)
        {
            sModulus = 0;
            return "1";
        }
        else if (ReturnLargerInteger( value,  divisor) == divisor)
        {
            sModulus = value;
            return "0";
        }

        string run = "0";
        StringBuilder sb = new StringBuilder();

        foreach (string item in value)
        {
            run = ScrubLeadingZeros( run + item);

            if (run == "0" || run == null)
            {
                run = "0";
                sb.Append("0");
                continue;
            }

            if (ReturnLargerInteger( divisor,  run) == run)
            {
                string s = string.Empty;
                string p = MegaIntegerSimpleDivide( run,  divisor,  s);
                sb.Append(p);
                run = s;
            }
        }

        sModulus = run;
        if (bNegative)
        {
            return MegaNegAbsolute( sb.ToString());
        }
        else
        {
            return sb.ToString();
        }

    }

    /// <summary>
    /// Multiply two very large numbers
    /// </summary>
    /// <param name="item1">number 1</param>
    /// <param name="item2">number 2</param>
    /// <returns>Product of multiplication</returns>
    /// <remarks></remarks>
    public static string MegaIntgerMultiply( string item1,  string item2)
    {
        bool bNeg = false;
        if (isNegative( item1) && isPositive( item2))
        {
            bNeg = true;
        }
        else if (isPositive( item1) && isNegative( item2))
        {
            bNeg = true;
        }

        string strTop = MegaAbsolute( ReturnLargerInteger( item1,  item2));
        string strBottom = MegaAbsolute( ReturnSmallerInteger( item1,  item2));

        ArrayList pList = new ArrayList();
        string xCounter = "0";

        foreach (object nBottom_loopVariable in strBottom.Reverse)
        {
            nBottom = nBottom_loopVariable;
            StringBuilder sb = new StringBuilder();
            Int16 carry = 0;

            string i = "0";
            while (!(i == xCounter))
            {
                sb.Insert(0, "0", 1);
                i = MegaIntegerAddition( i,  "1");
            }

            foreach (object nTop_loopVariable in strTop.Reverse)
            {
                nTop = nTop_loopVariable;
                string x = nTop.ToString();
                string y = nBottom.ToString();

                Int32 nresult = Convert.ToInt16(x) * Convert.ToInt16(y);

                nresult += carry;
                carry = 0;

                string sresult = nresult.ToString();
                Int32 lresult = sresult.Length;

                string drop = sresult.Substring(lresult - 1);
                string scarry = sresult.Substring(0, lresult - 1);

                if (!(scarry == null))
                {
                    carry = Convert.ToInt16(scarry);
                }

                sb.Insert(0, drop.ToString(), 1);
            }
            if (carry > 0)
                sb.Insert(0, carry.ToString(), 1);
            pList.Add(sb.ToString());
            xCounter = MegaIntegerAddition( xCounter,  "1");
        }

        string product = "0";

        foreach (string lItem in pList)
        {
            product = MegaIntegerAddition( product,  lItem);
        }

        if (bNeg)
        {
            return MegaNegAbsolute( product);
        }
        else
        {
            return product;
        }


    }

    /// <summary>
    /// Add two very large numbers
    /// </summary>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static string MegaIntegerAddition( string item1,  string item2)
    {
        bool negresult = false;

        if (isNegative( item1) && isNegative( item2))
        {
            negresult = true;
        }
        else if (isNegative( item1) && isPositive( item2))
        {
            if (MegaAbsolute( item1) == item2)
            {
                return "0";
                //items cancel out
            }
            if (ReturnLargerInteger( item2,  item1) == item2)
            {
                return MegaIntegerSubtraction( item2,  MegaAbsolute( item1));
            }
            else
            {
                return MegaIntegerSubtraction( MegaAbsolute( item1),  item2);
            }
        }
        else if (isNegative( item2) && isPositive( item1))
        {
            if (item1 == MegaAbsolute( item2))
            {
                return "0";
                //items cancel out
            }
            if (ReturnLargerInteger( item2,  item1) == item1)
            {
                return MegaIntegerSubtraction( item1,  MegaAbsolute( item2));
            }
            else
            {
                return MegaNegAbsolute( MegaIntegerSubtraction( item1,  MegaAbsolute( item2)));
            }
        }

        string aItem1 = MegaAbsolute( item1);
        string aItem2 = MegaAbsolute( item2);

        StringBuilder sb = new StringBuilder();
        Int16 carry = 0;
        long x = 0;

        while (!(x == aItem1.Length | x == aItem2.Length))
        {
            Int16 y = 0;
            Int16 z = 0;
            Int16 sum = 0;

            try
            {
                y = Convert.ToInt16(aItem1.Substring(aItem1.Length - x - 1, 1));
                z = Convert.ToInt16(aItem2.Substring(aItem2.Length - x - 1, 1));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sum = y + z;

            if (carry > 0)
            {
                sum += carry;
            }

            if (sum < 10)
            {
                sb.Insert(0, sum, 1);
                carry = 0;
            }
            else if (sum >= 10 && sum <= 19)
            {
                sb.Insert(0, sum - 10, 1);
                carry = 1;
            }

            x += 1;
        }

        if (aItem1.Length != aItem2.Length)
        {
            string sLong = string.Empty;
            string sShort = string.Empty;

            if (aItem1.Length > aItem2.Length)
            {
                sLong = aItem1;
                sShort = aItem2;
            }
            else
            {
                sLong = aItem2;
                sShort = aItem1;
            }

            Int64 diff = sLong.Length - sShort.Length;

            if (carry > 0)
            {
                string temp = sLong.Substring(0, diff);
                temp = MegaIntegerAddition( temp,  carry);
                sb.Insert(0, temp, 1);
            }
            else
            {
                string ext = sLong.Substring(0, diff);
                sb.Insert(0, ext, 1);
            }
        }
        else
        {
            if (carry > 0)
            {
                sb.Insert(0, carry, 1);
            }
        }

        if (negresult)
        {
            return "-" + sb.ToString();
        }
        else
        {
            return sb.ToString();
        }

    }

    /// <summary>
    /// Subtract two very large numbers (item1 - item2)
    /// </summary>
    /// <param name="item1">item1</param>
    /// <param name="item2">item2</param>
    /// <returns>Signed integer</returns>
    /// <remarks></remarks>
    public static string MegaIntegerSubtraction( string item1,  string item2)
    {
        bool bNegResult = false;

        //if oposite sign and same value
        if (isNegative( item1) && isPositive( item2))
        {
            if (MegaAbsolute( item1) == MegaAbsolute( item2))
            {
                return "0";
            }
            return MegaIntegerAddition( MegaNegAbsolute( item1),  MegaNegAbsolute( item2));
        }
        else if (isPositive( item1) && isNegative( item2))
        {
            return MegaIntegerAddition( item1,  item2);

        }
        else if (isNegative( item1) && isNegative( item2))
        {
            if (item1 == item2)
                return "0";
            if (ReturnLargerInteger( item1,  item2) == item2)
            {
                bNegResult = false;
            }
            else
            {
                bNegResult = true;
            }

        }
        else if (isPositive( item1) && isPositive( item2))
        {
            if (item1 == item2)
                return "0";
            if (ReturnLargerInteger( item1,  item2) == item2)
            {
                bNegResult = true;
            }

        }

        StringBuilder sb = new StringBuilder();
        Int16 carry = 0;
        string top = MegaAbsolute( ReturnLargerInteger( item2,  item1));
        string bottom = MegaAbsolute( ReturnSmallerInteger( item2,  item1));

        //even out bottom with leading 0s
        do
        {
            if (top.Length == bottom.Length)
                break; // TODO: might not be correct. Was : Exit Do
            bottom = "0" + bottom;
        } while (true);

        long x = 0;

        while (!(x == top.Length))
        {
            Int16 y = 0;
            Int16 z = 0;
            Int16 subtract = 0;
            Int16 drop = 0;
            try
            {
                y = Convert.ToInt16(top.Substring((int)(top.Length - x - 1), 1));
                z = Convert.ToInt16(bottom.Substring((int)(bottom.Length - x - 1), 1));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (carry > 0)
            {
                y -= carry;
            }

            //must carry from next power
            if (z > y)
            {
                carry = 1;
                drop = y + 10 - z;
            }
            else
            {
                carry = 0;
                drop = y - z;
            }

            if (drop > 10)
            {
                //mystery
            }

            sb.Insert(0, drop, 1);

            x += 1;
        }
        if (bNegResult)
        {
            return ScrubLeadingZeros( "-" + sb.ToString());
        }
        else
        {
            return ScrubLeadingZeros( sb.ToString());
        }


    }

    #endregion

    #region "Helper functions"

    protected static string MegaNegAbsolute( string num)
    {
        if (num.StartsWith("-"))
        {
            return num;
        }
        return "-" + num;
    }

    protected static string MegaAbsolute( string num)
    {
        if (num.StartsWith("-"))
        {
            num = num.Substring(1);
        }
        return num;
    }

    protected static bool isPositive( string num)
    {
        if (num.StartsWith("-"))
            return false;
        return true;
    }

    protected static bool isNegative( string num)
    {
        if (num.StartsWith("-"))
            return true;
        return false;
    }

    protected static string MegaIntegerSimpleDivide( string value,  string divisor,  string modulus)
    {
        string dividend = string.Empty;
        string count = "1";
        modulus = "0";

        do
        {
            dividend = MegaIntgerMultiply( count,  divisor);

            if (dividend == value)
            {
                return count;
                modulus = "0";
                //end the loop
            }
            else if (ReturnLargerInteger( dividend,  value) == dividend)
            {
                string input = "1";
                string product = MegaIntegerSubtraction( count,  input);
                string z = MegaIntgerMultiply( product,  divisor);
                modulus = ScrubLeadingZeros( MegaIntegerSubtraction( value,  z));
                return product;
            }
            string input = "1";
            count = MegaIntegerAddition( count,  input);
        } while (true);

    }

    protected static string ScrubLeadingZeros( string value)
    {
        do
        {
            if (value.StartsWith("0"))
            {
                value = value.Substring(1);
            }
            else
            {
                break; // TODO: might not be correct. Was : Exit Do
            }
        } while (true);
        return value;
    }

    #endregion

    #region "Other"

    public static string ReturnLargerInteger( string item1,  string item2)
    {


        string aItem1 = MegaAbsolute( item1);
        string aItem2 = MegaAbsolute( item2);

        if (aItem1.Length > aItem2.Length)
        {
            return item1;
        }

        if (aItem2.Length > aItem1.Length)
        {
            return item2;
        }

        Int64 x = 0;

        while (!(x == aItem1.Length))
        {
            Int16 y = 0;
            Int16 z = 0;
            y = Convert.ToInt16(aItem1.Substring((int)x, 1));
            z = Convert.ToInt16(aItem2.Substring((int)x, 1));

            if (y > z)
            {
                return item1;
            }

            if (y < z)
            {
                return item2;
            }

            x += 1;
        }
        return item1;
    }

    public static string ReturnSmallerInteger( string item1,  string item2)
    {
        if (item1.Length > item2.Length)
        {
            return item2;
        }

        if (item2.Length > item1.Length)
        {
            return item1;
        }

        Int64 x = 0;

        while (!(x == item1.Length))
        {
            Int16 y = 0;
            Int16 z = 0;
            y = Convert.ToInt16(item1.Substring((int)x, 1));
            z = Convert.ToInt16(item2.Substring((int)x, 1));

            if (y > z)
            {
                return item2;
            }

            if (y < z)
            {
                return item1;
            }

            x += 1;
        }
        return item1;
        //items should be the same if execution reaches this point...
    }

    /// <summary>
    /// Calculate the Collatz trajectory for a given number
    /// </summary>
    /// <param name="num">Integer to calculate</param>
    /// <remarks></remarks>
    public static void Collatz( string num)
    {
        string jumps = "0";

        string cal = string.Empty;
        cal = num;
        do
        {
            if (cal.EndsWith("2") || cal.EndsWith("4") | cal.EndsWith("6") | cal.EndsWith("8") | cal.EndsWith("0"))
            {
                cal = MegaIntegerDivide(cal, "2","");
            }
            else
            {
                cal = MegaIntgerMultiply( cal,  "3");
                cal = MegaIntegerAddition( cal,  "1");
            }
            Console.WriteLine(cal);
            jumps = MegaIntegerAddition( jumps,  "1");
            if (cal == "1")
                break; // TODO: might not be correct. Was : Exit Do
        } while (true);
        Console.WriteLine();
        Console.WriteLine("Jumps: " + jumps);
    }

    #endregion

}
#endregion

#endregion
