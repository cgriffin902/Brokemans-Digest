using BrokeMans.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokeMans.Adapters
{
    interface IComments
    {
        Comment CreateComment( Comment comment,int id);
    }
}
