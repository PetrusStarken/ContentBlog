namespace BusinessServices
{
    using BusinessEntities;
    using DataModel;
    using DataModel.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Transactions;
    using System.Linq;

    public class LeadServices : MapperConfiguration<DataModel.Lead, LeadEntity>, ILeadServices
    {
        private readonly UnitOfWork _unitOfWork;

        public LeadServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(LeadEntity leadEntity)
        {
            using (var scope = new TransactionScope())
            {
                var lead = new Lead()
                {
                    Nome = leadEntity.Nome,
                    Email = leadEntity.Email,
                    DataRegistro = DateTime.Now
                };

                _unitOfWork.LeadRepository.Insert(lead);
                _unitOfWork.Save();
                scope.Complete();

                return lead.Id;
            }
        }

        public LeadEntity Get(int leadId)
        {
            var lead = _unitOfWork.LeadRepository.GetByID(leadId);

            if (lead == null)
                return null;

            var leadModel = _mapper.Map<Lead, LeadEntity>(lead);
            return leadModel;
        }

        public IEnumerable<LeadEntity> GetAll()
        {
            var lead = _unitOfWork.LeadRepository.GetAll().ToList();

            if (!lead.Any())
                return null;

            var leadModel = _mapper.Map<List<Lead>, List<LeadEntity>>(lead);
            return leadModel;
        }

    }
}
