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
            public const int AddressMinLenght = 20;
            public const int AddressMaxLenght = 100;
            public const int PhoneMinLenght = 4;
            public const int PhoneMaxLenght = 20;
            public const int CityMinLenght = 3;
            public const int CityMaxLenght = 15;
            public const int EmailMinLenght = 25;
            public const int EmailMaxLenght = 85;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
            public const string CityFilterRegex = "^[A-Za-z]+(?:\\s+[A-Za-z]+)*$";
        }

        public static class Judge
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLenght = 50;
            public const int DescriptionMaxLenght = 500;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
        }

        public static class Article
        {
            public const int TittleMinLenght = 20;
            public const int TittleMaxLenght = 100;
            public const int DescriptionMinLenght = 100;
            public const int DescriptionMaxLenght = 3000;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
        }

        public static class Manager
        {
            public const int PhoneNumberMinLength = 4;
            public const int PhoneNumberMaxLength = 15;
            public const int ReasonMinLenght = 25;
            public const int ReasonMaxLenght = 100;
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
            public const int PriceMinLenght = 1;
            public const int PriceMaxLenght = 10;
            public const int DescriptionMinLenght = 100;
            public const int DescriptionMaxLenght = 600;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
        }

        public static class Order
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int PhoneMinLenght = 4;
            public const int PhoneMaxLenght = 20;
            public const int EmailMinLenght = 25;
            public const int EmailMaxLenght = 85;
            public const int PasswordMinLenght = 6;
            public const int PasswordMaxLenght = 100;
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
