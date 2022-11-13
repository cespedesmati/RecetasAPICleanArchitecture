using Domain.Interfaces;
using Domain;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public class StepRepository : GenericRepository<Step>, IStepRepository
{
    public StepRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
