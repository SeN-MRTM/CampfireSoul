using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  public class Resource : Entity
    {

    public override string Name { get; set; }
    public override string Description { get; set; }
    public override int Id { get; set; }
    public override bool IsDeleted { get; set; }

}

