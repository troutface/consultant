using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FamilyHistoryConsultant
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            Mapper.Initialize(config =>
            {
              config.CreateMap<Models.MemberRecord, Data.MemberRecord>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.MemberRecordId, opts => opts.MapFrom(src => src.Id));
              config.CreateMap<Models.Household, Data.Household>()
                .ForMember(dest => dest.Id, opts => opts.Ignore());
                //.ForMember(dest => dest.HeadOfHouseIndividualId, opts => opts.MapFrom(src => src.HeadOfHouseIndividualId));
              config.CreateMap<Models.Child, Data.Child>()
                .ForMember(dest => dest.Id, opts => opts.Ignore());
              //  .ForMember(dest => dest.IndividualId, opts => opts.MapFrom(src => src.IndividualId));
              config.CreateMap<Models.HeadOfHouse, Data.HeadOfHouse>()
                .ForMember(dest => dest.Id, opts => opts.Ignore());
              //  .ForMember(dest => dest.IndividualId, opts => opts.MapFrom(src => src.IndividualId));
              config.CreateMap<Models.Spouse, Data.Spouse>()
                .ForMember(dest => dest.Id, opts => opts.Ignore());
              //  .ForMember(dest => dest.IndividualId, opts => opts.MapFrom(src => src.IndividualId));
            });
        }
    }
}