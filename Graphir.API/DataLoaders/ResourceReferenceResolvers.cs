using Hl7.Fhir.Model;
using HotChocolate;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

using Location = Hl7.Fhir.Model.Location;

namespace Graphir.API.DataLoaders
{
    public class ResourceReferenceResolvers
    {
        /// <summary>
        /// Fetches referenced resources based on relative Url of 'reference' property.
        /// * only relative links supported at this time
        /// <example>
        /// 'Patient/1234'
        /// </example>
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="factory"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Resource?> GetResourceAsync(
            [Parent] ResourceReference parent,
            [Service] DataLoaderFactory factory,
            CancellationToken cancellationToken)
        {
            var refString = parent.Reference;
            
            var resourceType = refString?.Split('/').FirstOrDefault();
            var resourceId = refString?.Split('/').LastOrDefault();

            switch (resourceType)
            {
                default:
                    return null;
                case nameof(Appointment):
                    return await factory.AppointmentByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Patient):
                    return await factory.PatientByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Practitioner):
                    return await factory.PractitionerByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Location):
                    return await factory.LocationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Condition):
                    return await factory.ConditionByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Coverage):
                    return await factory.CoverageByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Device):
                    return await factory.DeviceByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Provenance):
                    return await factory.ProvenanceByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Slot):
                    return await factory.SlotByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Medication):
                    return await factory.MedicationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(MedicationAdministration):
                    return await factory.MedicationAdministrationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(MedicationRequest):
                    return await factory.MedicationRequestByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Schedule):
                    return await factory.ScheduleByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(HealthcareService):
                    return await factory.HealthServiceByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Group):
                    return await factory.GroupByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Organization):
                    return await factory.OrganizationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Endpoint):
                    return await factory.EndpointByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Encounter):
                    return await factory.EncounterByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(RelatedPerson):
                    return await factory.RelatedPersonByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(DetectedIssue):
                    return await factory.DetectedIssueByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Immunization):
                    return await factory.ImmunizationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(MedicationDispense):
                    return await factory.MedicationDispenseByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(MedicationStatement):
                    return await factory.MedicationStatementByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Observation):
                    return await factory.ObservationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Procedure):
                    return await factory.ProcedureByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(QuestionnaireResponse):
                    return await factory.QuestionnaireResponseByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Questionnaire):
                    return await factory.QuestionnaireByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Specimen):
                    return await factory.SpecimenByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Substance):
                    return await factory.SubstanceByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(AllergyIntolerance):
                    return await factory.AllergyIntoleranceByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(CarePlan):
                    return await factory.CarePlanByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(CareTeam):
                    return await factory.CareTeamByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Claim):
                    return await factory.ClaimByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(ClaimResponse):
                    return await factory.ClaimResponseByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Communication):
                    return await factory.CommunicationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(CommunicationRequest):
                    return await factory.CommunicationRequestByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Composition):
                    return await factory.CompositionByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Consent):
                    return await factory.ConsentByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Contract):
                    return await factory.ContractByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(DeviceRequest):
                    return await factory.DeviceRequestByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(DeviceUseStatement):
                    return await factory.DeviceUseStatementByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(EnrollmentRequest):
                    return await factory.EnrollmentRequestByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(EnrollmentResponse):
                    return await factory.EnrollmentResponseByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(EpisodeOfCare):
                    return await factory.EpisodeOfCareByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(ExplanationOfBenefit):
                    return await factory.ExplanationOfBenefitByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(FamilyMemberHistory):
                    return await factory.FamilyMemberHistoryByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
               case nameof(Flag):
                    return await factory.FlagByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Goal):
                    return await factory.GoalByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(ImagingStudy):
                    return await factory.ImagingStudyByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(ImmunizationEvaluation):
                    return await factory.ImmunizationEvaluationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(ImmunizationRecommendation):
                    return await factory.ImmunizationRecommendationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(ImplementationGuide):
                    return await factory.ImplementationGuideByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Library):
                    return await factory.LibraryByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Linkage):
                    return await factory.LinkageByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(List):
                    return await factory.ListByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Measure):
                    return await factory.MeasureByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(MeasureReport):
                    return await factory.MeasureReportByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Media):
                    return await factory.MediaByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(NutritionOrder):
                    return await factory.NutritionOrderByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(PaymentNotice):
                    return await factory.PaymentNoticeByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(PaymentReconciliation):
                    return await factory.PaymentReconciliationByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(Person):
                    return await factory.PersonByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(PlanDefinition):
                    return await factory.PlanDefinitionByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(PractitionerRole):
                    return await factory.PractitionerRoleByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
                case nameof(ServiceRequest):
                    return await factory.ServiceRequestByIdDataLoader.LoadAsync(resourceId!, cancellationToken);
            }
        }
    }
}
