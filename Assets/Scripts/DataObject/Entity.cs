using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public abstract class Entity
    {

    public abstract string Name { get; set; }
    public abstract string Description { get; set; }
    public abstract int Id { get; set; }
    public abstract bool IsDeleted { get; set; }



    }

