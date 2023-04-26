using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; set; }

        public static MapperConfiguration MapperConfiguration { get; set; }

        public static void Initialize(MapperConfiguration mapperConfiguration)
        {
            MapperConfiguration = mapperConfiguration;
            Mapper = mapperConfiguration.CreateMapper();
        }



    }
}
