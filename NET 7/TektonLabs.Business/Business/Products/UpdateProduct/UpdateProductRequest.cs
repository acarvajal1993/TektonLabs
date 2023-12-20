﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TektonLabs.Core.Business.Productos.ActualizarProducto
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public int Stock { get; set; }
        public decimal Price { get; set; }  
        public bool Status { get; set; }    
    }
}
