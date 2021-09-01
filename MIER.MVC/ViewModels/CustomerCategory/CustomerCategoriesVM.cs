using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIER.MVC.ViewModels.CustomerCategory
{
    public class CustomerCategoriesVM
    {
        public bool IsEditMode => Id.HasValue;

        public int? Id { get; set; }

        public string Name { get; set; }

        public bool IsTaxable { get; set; }

    }
}
