using AutoMapper;
using IGotUScraper.Application.Mapper;
using IGotUScraper.Infrastructure.Mapper;

namespace IGotUScraper.Api.UnitTests.Mapper
{
    public class MapperFixture
    {
        public IMapper Mapper { get; }


        public MapperFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new AutoMapperApplicationProfile());
                opts.AddProfile(new AutoMapperRepositoryProfile());
            });

            Mapper = config.CreateMapper();
        }
    }
}
