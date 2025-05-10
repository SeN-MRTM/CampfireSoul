using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Mob : Entity
{

    public override string Name { get; set; }
    public override string Description { get; set; }
    public override int Id { get; set; }
    public override bool IsDeleted { get; set; }

    public abstract List<Item> Drops { get; set; }

}

