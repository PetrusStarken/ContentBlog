namespace BusinessServices
{
    using BusinessEntities;
    using System.Collections.Generic;

    public interface ILeadServices
    {
        int Add(LeadEntity leadEntity);
        LeadEntity Get(int leadId);
        IEnumerable<LeadEntity> GetAll();
    }
}
