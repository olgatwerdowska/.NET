using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc4.Models
{
    public class TestModel
    {  
        public string TypeProdukt {get;set;}
        public double Price {get;set;}

        public string Description{get;set;}
    }
}