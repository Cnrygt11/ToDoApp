using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Business.Constants
{
    public static class Messages
    {
        //Assignment Messages
        public static string AssignmentDeleted = "Assingment deleted succesfully.";
        public static string AssignmentListed = "Assignments listed successfully.";
        public static string AssignmentUpdated = "Assignment has been updated successfully.";
        public static string AssignmentNotFound = "Assignment not found.";
        public static string AssignmentNameInvalid = "Assignment name must be at least 2 and at most 30 characters long.";
        public static string AssignmentAdded = "Assignment has been added successfully.";
        public static string AssignmentLimitExceeded = "You cannot add more than 15 assignments to a list.";    
        public static string AssignmentNameAlreadyExists = "Assignment name already exists. Please choose a different name.";
        
        //Assignment List Messages
        public static string AssignmentListListed = "Lists listed successfully.";
        public static string AssignmentListDeleted = "Assignment list deleted successfully.";
        public static string AssignmentListNameAlreadyExists = "Assignment list name already exists. Please choose a different name.";
        public static string AssignmentListUpdated = "Assignment list has been updated successfully.";
        public static string AssignmentListAdded = "Assignment list has been added successfully.";
        public static string AssignmentListNotFound = "Assignment list not found.";
        public static string AssignmentListNameInvalid = "Assignment list name must be at least 2 and at most 50 characters long.";
        public static string AssignmentListNameEmpty = "Assignment list name cannot be empty.";

        //Register Messages
        public static string RegisterSuccessful = "Registered successfully.";
        public static string RegisterFailed = "Register failed.";
        public static string UsernameInvalid = "Username invalid.";
        public static string PasswordInvalid = "Password invalid.";

        //Login Messages
        public static string LoginSuccessful = "Logged in succesfully.";
        public static string LoginFailed = "Login failed.";
        public static string UsernameInvalidLogin = "Username or password invalid.";

        //Token Messages
        public static string AuthorizationDenied = "You are not authorized.";
        public static string TokenExpired = "Token has expired.";
        public static string TokenInvalid = "Token is invalid.";

        //Login-Register Messages
        public static string UserRegistered = "User has been successfully registered.";
        public static string UserAlreadyExists = "A user with this email already exists.";
        public static string PasswordsDoNotMatch = "Passwords do not match.";
        public static string WeakPassword = "Password is too weak.";
        public static string InvalidEmailFormat = "Please enter a valid email address.";
        public static string EmailCannotBeEmpty = "Email cannot be empty.";
        public static string PasswordTooShort = "Password must be at least 6 characters long.";
        public static string UsernameTooShort = "Username must be at least 3 characters long.";
        public static string UsernameAlreadyExists = "Username already exists. Please choose a different username.";
        public static string EmailAlreadyInUse = "This email already in use.";
        public static string UserNotFound = "User not found.";
        public static string PasswordError = "Incorrect password.";
        public static string SuccessfulLogin = "Login successful.";
        public static string AccountLocked = "Your account is temporarily locked. Please try again later.";
        public static string UsernameCannotBeEmpty = "Username cannot be empty.";
        public static string PasswordCannotBeEmpty = "Password cannot be empty.";
        public static string InvalidEmailDomain = "Email domain is not allowed.";
        public static string UsernameTooLong = "Username cannot be longer than 20 characters.";
        public static string UsernameInvalidCharacters = "Username can only contain letters, numbers, dots, hyphens, and underscores.";
        public static string PasswordMustContainUppercase = "Password must contain at least one uppercase letter.";
        public static string PasswordMustContainLowercase = "Password must contain at least one lowercase letter.";
        public static string PasswordMustContainDigit = "Password must contain at least one digit.";
        public static string PasswordMustContainSpecialChar = "Password must contain at least one special character (@$!%*?&).";
        public static string PasswordConfirmationRequired = "Password confirmation is required.";





    }
}
