using System;

namespace DrugApiTesting
{
    internal class DrugsApiController
    {
        private IProvider @object;

        public DrugsApiController(IProvider @object)
        {
            this.@object = @object;
        }

        internal BadRequestResult getDispatchableDrugStock(int v, object p)
        {
            throw new NotImplementedException();
        }

        internal object searchDrugsByName(string v)
        {
            throw new NotImplementedException();
        }

        internal BadRequestResult searchDrugsByID(int v)
        {
            throw new NotImplementedException();
        }
    }
}