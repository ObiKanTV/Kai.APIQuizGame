using Assets.Scripts.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IGetCategoriesSelectList
    {
        public IEnumerable<Category> GetCategories();
        public Task AddOptionsToDropdown(IEnumerable<Category> categories);
        public bool ClearDropdown(object dropdown);

    }
}
