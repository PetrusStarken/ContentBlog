namespace BusinessServices
{
    using AutoMapper;

    public class MapperConfiguration<DataModel, Entity>
    {
        protected readonly IMapper _mapper;
        public MapperConfiguration()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataModel, Entity>();
            }).CreateMapper();
        }
    }
}