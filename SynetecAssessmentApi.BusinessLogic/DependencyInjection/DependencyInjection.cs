using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.DataAccess.Repositories;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;

namespace SynetecAssessmentApi.BusinessLogic.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void SetDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
