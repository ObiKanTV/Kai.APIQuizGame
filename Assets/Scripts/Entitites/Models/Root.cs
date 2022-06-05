using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entitites.Models
{
    public class Root
    {
        public int response_code { get; set; }
        public List<Result> results { get; set; } = new List<Result>();
        public List<Category> categories { get; set; } = new List<Category>();
    }
}

