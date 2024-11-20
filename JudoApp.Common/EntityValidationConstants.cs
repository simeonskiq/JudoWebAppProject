namespace JudoApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Club
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int AddressMinLenght = 20;
            public const int AddressMaxLenght = 100;
            public const int PhoneMinLenght = 4;
            public const int PhoneMaxLenght = 15;
            public const int CityMinLenght = 3;
            public const int CityMaxLenght = 15;
            public const int EmailMinLenght = 25;
            public const int EmailMaxLenght = 85;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
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
    }
}
