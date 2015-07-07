using BrokeMans.Data.Models;
using BrokeMans.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokeMans.Adapters
{
    interface IItem
    {
        ItemViewModel GetItemDetails(int id);
        ItemListViewModel Get4ItemPics();
        ItemListViewModel GetAllItems();
        Item Create(Item item,ApplicationUser user );
        Item GetEdit(Item item, ApplicationUser user, int id);
        Item PostEdit(Item item, int id);
        void Delete(int id);
    }
}
