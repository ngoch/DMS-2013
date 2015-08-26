using AutoMapper.Configuration;
using DMS.Domain;
using DMS.Web.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.App_Start
{
    public class MapperConfig
    {
        public static void Configure(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectTableRowModel>()
                .ForMember(x => x.AllAssessments, y => y.ResolveUsing(x => x.Assessments.Count()))
                .ForMember(x => x.ConfirmedAssessments, y => y.ResolveUsing(x => x.Assessments.Where(ass => ass.Confirmed).Count()));
            configuration.CreateMap<AddProjectViewModel, Project>()
                .ForMember(destination => destination.Experts, destination => destination.Ignore());
            configuration.CreateMap<Project, AddProjectViewModel>()
                .ForMember(destination => destination.Users, destination => destination.ResolveUsing(source => source.Experts.Select(x => x.UserId).ToArray()));

            configuration.CreateMap<AlternativeModel, Alternative>()
                .ForMember(destinationMember => destinationMember.AlternativeName, destination => destination.ResolveUsing(source => source.Name));
            configuration.CreateMap<FactorModel, Factor>()
                .ForMember(destinationMember => destinationMember.FactorName, destination => destination.ResolveUsing(source => source.Name));

            configuration.CreateMap<Alternative, AlternativeModel>()
                .ForMember(destinationMember => destinationMember.Name, destination => destination.ResolveUsing(source => source.AlternativeName));
            configuration.CreateMap<Factor, FactorModel>()
                .ForMember(destinationMember => destinationMember.Name, destination => destination.ResolveUsing(source => source.FactorName));

            configuration.CreateMap<ExpertAssessment, AssessmentTableRowModel>()
                .ForMember(destination => destination.ProjectName, destination => destination.ResolveUsing(source => source.Project.Name));

            configuration.CreateMap<ExpertAssessment, AssessmentDetailsViewModel>();
        }
    }
}