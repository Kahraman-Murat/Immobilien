﻿using Immobilien.Business.Abstract;
using Immobilien.Business.Concrete;
using Immobilien.DataAccess.Abstract;
using Immobilien.DataAccess.EntityFramework;
using Immobilien.DataAccess.Repositories;

namespace Immobilien.WebUI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IBannerDal, EfBannerDal>();
            services.AddScoped<IBannerService, BannerManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<ICounterDal, EfCounterDal>();
            services.AddScoped<ICounterService, CounterManager>();

            services.AddScoped<IDealDal, EfDealDal>();
            services.AddScoped<IDealService, DealManager>();

            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IQuestDal, EfQuestDal>();
            services.AddScoped<IQuestService, QuestManager>();

            services.AddScoped<ISubHeaderDal, EfSubHeaderDal>();
            services.AddScoped<ISubHeaderService, SubHeaderManager>();

            services.AddScoped<IVideoDal, EfVideoDal>();
            services.AddScoped<IVideoService, VideoManager>();

            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            
        }

    }
}
