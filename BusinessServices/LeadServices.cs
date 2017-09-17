namespace BusinessServices
{
    using BusinessEntities;
    using DataModel;
    using DataModel.UnitOfWork;
    using System.Transactions;

    public class LeadServices : ILeadServices
    {
        private readonly UnitOfWork _unitOfWork;

        public LeadServices()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int Add(LeadEntity leadEntity)
        {
            using (var scope = new TransactionScope())
            {
                var lead = new Lead()
                {
                    Nome = leadEntity.Nome,
                    Email = leadEntity.Email
                };

                _unitOfWork.LeadRepository.Insert(lead);
                _unitOfWork.Save();
                scope.Complete();

                return lead.Id;
            }
        }
    }
}
