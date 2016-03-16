"use strict";
var User = (function () {
    function User(Name, Username, Email, Password, Phone, Genre, DOB) {
        this.Name = Name;
        this.Username = Username;
        this.Email = Email;
        this.Password = Password;
        this.Phone = Phone;
        this.Genre = Genre;
        this.DOB = DOB;
    }
    ;
    return User;
}());
exports.User = User;
var LoginRes = (function () {
    function LoginRes() {
    }
    return LoginRes;
}());
exports.LoginRes = LoginRes;
