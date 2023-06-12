namespace ShoppingListApp.Core.Constants
{
    public static class ViewModelConstants
    {
        public static class User
        {
            public const int MaxUsernameLength = 20;
            public const int MinUsernameLength = 3;

            public const int MaxFirstNameLength = 30;
            public const int MinFirstNameLength = 2;

            public const int MaxLastNameLength = 30;
            public const int MinLastNameLength = 2;

            public const int MaxEmaildLength = 60;
            public const int MinEmailLength = 10;

            public const int MaxPasswordLength = 20;
            public const int MinPasswordLength = 5;
        }

        public static class Category
        {
            public const int MaxCategoryName = 50;
            public const int MinCategoryName = 3;
        }

        public static class Product
        {
            public const int MaxProductName = 50;
            public const int MinProductName = 3;

            public const int MaxProductDescription = 500;
            public const int MinProductDescription = 3;

            public const int MaxProductImageUrl = 300;            

            public const string MaxProductPrice = "100000";
            public const string MinProductPrice = "0.0";
        }
    }
}
