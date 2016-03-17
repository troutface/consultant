using AutoMapper;

namespace FamilyHistoryConsultant.Infrastructure.Mapping {
  public interface IHaveCustomMappings {
    void CreateMappings(IConfiguration configuration);
  }
}