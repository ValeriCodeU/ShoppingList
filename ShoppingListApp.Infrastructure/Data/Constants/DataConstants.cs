using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Infrastructure.Data.Constants
{
    public static class DataConstants
    {
        public static class ApplicationUser
        {
            public const int MaxUserFirstName = 50;
            public const int MaxUserLastName = 50;
        }

        public static class Category
        {
            public const int MaxCategoryName = 50;
        }

        public static class Product
        {
            public const int MaxProductName = 50;
            public const int MaxProductDescription = 500;
            public const int MaxProductImageUrl = 300;

            public const int PrecisionDecimal = 18;
            public const int ScaleDecimal = 2;           
        }
    }
}
