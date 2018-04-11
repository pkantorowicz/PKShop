namespace PKShop.Core.Exceptions
{
    class ErrorCodes
    {
        public static string EmailInUse => "email_in_use";
        public static string InvalidCredentials => "invalid_credentials";
        public static string InvalidName => "invalid_name";
        public static string InvalidCurrentPassword => "invalid_current_password";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidPassword => "invalid_password";
        public static string InvalidRole => "invalid_role";
        public static string RefreshTokenNotFound => "refresh_token_not_found";
        public static string RefreshTokenAlreadyRevoked => "refresh_token_already_revoked";
        public static string UserNotFound => "user_not_found";
        public static string InvalidCountry => "invalid_country";
        public static string InvalidTotalCost => "invalid_total_cost";
        public static string InvalidTotalTax => "invalid_total_tax";
        public static string InvalidFirstName => "invalid_first_name";
        public static string InvalidLastName => "invalid_last_name";
        public static string InvalidCompanyName => "invalid_company_name";
        public static string InvalidBalance => "invalid_balance";
        public static string InvalidCardNumber => "invalid_card_number";
        public static string InvalidNameOnCard => "invalid_name_of_card";
        public static string CardExpired => "card_was_expired";
        public static string CreditCardAlreadyExists => "credit_card_already_exists";
        public static string CreditCardNotFound => "credit_card_not_found";
        public static string InvalidProductCode => "invalid_product_code";
    }
}
