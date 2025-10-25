namespace JudoApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Club
        {
            public const int IdMinLength = 36;
            public const int IdMaxLength = 36;
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int AddressMinLength = 20;
            public const int AddressMaxLength = 100;
            public const int PhoneMinLength = 4;
            public const int PhoneMaxLength = 20;
            public const int CityMinLength = 3;
            public const int CityMaxLength = 15;
            public const int EmailMinLength = 25;
            public const int EmailMaxLength = 85;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
            public const string CityFilterRegex = "^[A-Za-z]+(?:\\s+[A-Za-z]+)*$";
        }

        public static class Judge
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
        }

        public static class Article
        {
            public const int TittleMinLength = 20;
            public const int TittleMaxLength = 100;
            public const int DescriptionMinLength = 100;
            public const int DescriptionMaxLength = 3000;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
        }

        public static class Manager
        {
            public const int PhoneNumberMinLength = 4;
            public const int PhoneNumberMaxLength = 15;
            public const int ReasonMinLength = 25;
            public const int ReasonMaxLength = 100;
        }

        public static class ManagerRequest
        {
            public const int ReasonMinLength = 30;
            public const int ReasonMaxLength = 300;
        }

        public static class Product
        {
            public const int NameMinLength = 10;
            public const int NameMaxLength = 50;
            public const int PriceMinLength = 1;
            public const int PriceMaxLength = 10;
            public const int DescriptionMinLength = 100;
            public const int DescriptionMaxLength = 600;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
        }

        public static class Order
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int PhoneMinLength = 4;
            public const int PhoneMaxLength = 20;
            public const int EmailMinLength = 25;
            public const int EmailMaxLength = 85;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
            public const int AddressMinLength = 10;
            public const int AddressMaxLength = 50;
            public const int CityMinLength = 3; 
            public const int CityMaxLength = 50;
            public const int PostalCodeMinLength = 4;
            public const int PostalCodeMaxLength = 10;
            public const int CountryMinLength = 3;
            public const int CountryMaxLength = 50;
            public const int ShippingMethodMaxLength = 50;
            public const int PaymentMethodMaxLength = 50;
            public const int StatusMaxLength = 20;
            public const int OrderNumberMinLength = 5;
            public const int OrderNumberMaxLength = 20;
            public const int OrderNotesMaxLength = 250;
        }
    }
}
