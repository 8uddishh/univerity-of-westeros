namespace UoW.Students.Martell.Web.Pipelines
{
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.OData.Edm;
    using UoW.Students.Martell.Application;
    using UoW.Students.Martell.Application.Common.Brokers;
    using UoW.Students.Martell.Application.Courses;
    using UoW.Students.Martell.Application.StudentCourses;
    using UoW.Students.Martell.Application.Students;
    using UoW.Students.Martell.Application.StudentStatusTypes;
    using UoW.Students.Martell.Domains.Enums;
    using UoW.Students.Martell.Web.Pipelines.Middlewares;

    public class MvcOdataPipeline : IMiddlewarePipeline
    {
        public PipelineOrder Step => PipelineOrder.MvcOdata;

        private IEdmModel GetAggregateEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<CourseAggregateDto>("courses");
            odataBuilder.EntitySet<StudentAggregateDto>("students");
            odataBuilder.EntitySet<StudentCourseAggregateDto>("student-courses");
            odataBuilder.EntitySet<StudentStatusTypeAggregateDto>("student-status-types");

            return odataBuilder.GetEdmModel();
        }

        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<CourseDto>("courses");
            odataBuilder.EntitySet<StudentDto>("students");
            odataBuilder.EntitySet<StudentCourseDto>("student-courses");
            odataBuilder.EntitySet<StudentStatusTypeDto>("student-status-types");

            return odataBuilder.GetEdmModel();
        }

        public void Pipe(IApplicationBuilder app, IConfiguration configuration, string environment)
        {
            app.UseRouting();
            app.UseMiddleware<OdataPaginationMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.Select().Filter().OrderBy().MaxTop(500).Expand().Count();
                endpoints.MapODataRoute("odata", "odata", GetEdmModel());
                endpoints.MapODataRoute("odata", "odata/aggregates", GetAggregateEdmModel());
            });
        }
    }
}
