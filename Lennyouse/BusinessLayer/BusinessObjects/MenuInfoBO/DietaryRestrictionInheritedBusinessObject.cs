using Recodme.RD.Lennyouse.BusinessLayer.Base;
using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO
{
    public class DietaryRestrictionInheritedBusinessObject : BaseBusinessObject
    {
        private DietaryRestrictionDataAccessObject _dao;

        public OperationResult<List<DietaryRestriction>> List()
        {
            return ExecuteTransaction(() => _dao.List());
        }
        public OperationResult Create(DietaryRestriction dietaryRestriction)
        {
            return ExecuteOperation(() => _dao.Create(dietaryRestriction));
        }

        public OperationResult<DietaryRestriction> Read(Guid id)
        {
            return ExecuteTransaction(() => _dao.Read(id));
        }

        public OperationResult Update(DietaryRestriction dietaryRestriction)
        {
            return ExecuteOperation(() => _dao.Update(dietaryRestriction));
        }

        public OperationResult Delete(DietaryRestriction dietaryRestriction)
        {
            return ExecuteOperation(() => _dao.Delete(dietaryRestriction));
        }


    }
}
