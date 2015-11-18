using System;
using Folke.Social.Facebook;
using Microsoft.Extensions.DependencyInjection;

namespace Folke.Social
{
    public static class SocialServiceCollectionExtensions
    {
        public static IServiceCollection AddFacebookSocial(this IServiceCollection services, Action<FacebookOptions> options = null)
        {
            if (options != null)
            {
                services.Configure(options);
            }

            return services.AddScoped<ISocialGraph, FacebookGraph>();
        }
    }
}
