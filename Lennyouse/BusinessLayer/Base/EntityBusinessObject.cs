using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.Base
{
    public class EntityBusinessObject<T> : BaseBusinessObject where T : Entity
    {
        private BaseDataAccessObject<T> _dao;
        public EntityBusinessObject()
        {
            _dao = new BaseDataAccessObject<T>();
        }

        #region List
        public OperationResult<List<T>> List()
        {
            return ExecuteOperation(() => _dao.List());
        }

        public async Task<OperationResult<List<T>>> ListAsync()
        {
            return await ExecuteOperationAsync(() => _dao.ListAsync());
        }
        #endregion

        #region Create
        public OperationResult Create(T item)
        {
            return ExecuteOperation(()=>_dao.Create(item));
        }

        public async Task<OperationResult> CreateAsync(T item)
        {
            return await ExecuteOperationAsync(() => _dao.CreateAsync(item));
        }
        #endregion



        #region Read
        public OperationResult<T> Read(Guid id)
        {
            return ExecuteOperation(() => _dao.Read(id));
        }

        public async Task<OperationResult<T>> ReadAsync(Guid id)
        {
            return await ExecuteOperationAsync(() => _dao.ReadAsync(id));
        }
        #endregion


        #region Update
        public OperationResult Update(T item)
        {
            return ExecuteOperation(() => _dao.Update(item));
        }

        public async Task<OperationResult> UpdateAsync(T item)
        {
            return await ExecuteOperationAsync(() => _dao.UpdateAsync(item));
        }
        #endregion


        #region Delete
        public OperationResult Delete(T item)
        {
            return ExecuteOperation(() => _dao.Delete(item));
        }

        public async Task<OperationResult> DeleteAsync(T item)
        {
            return await ExecuteOperationAsync(() => _dao.DeleteAsync(item));
        }

        public OperationResult Delete(Guid id)
        {
            return ExecuteOperation(() => _dao.Delete(id));
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            return await ExecuteOperationAsync(() => _dao.DeleteAsync(id));
        }
        #endregion
    }
}
