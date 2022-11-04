using Hl7.Fhir.Model;

namespace Graphir.API.DataLoaders
{
    public class DataLoaderFactory
    {
        public DataLoaderFactory(
            ResourceByIdDataLoader<Account> accountByIdDataLoader,
            ResourceByIdDataLoader<Appointment> appointmentByIdDataLoader,
            ResourceByIdDataLoader<Patient> patientByIdDataLoader,
            ResourceByIdDataLoader<Practitioner> practitionerByIdDataLoader,
            ResourceByIdDataLoader<Location> locationByIdDataLoader,
            ResourceByIdDataLoader<Condition> conditionByIdDataLoader,
            ResourceByIdDataLoader<Coverage> coverageByIdDataLoader,
            ResourceByIdDataLoader<Device> deviceByIdDataLoader,
            ResourceByIdDataLoader<DeviceDefinition> deviceDefinitionByIdDataLoader,
            ResourceByIdDataLoader<Provenance> provenanceByIdDataLoader,
            ResourceByIdDataLoader<Slot> slotByIdDataLoader,
            ResourceByIdDataLoader<Medication> medicationByIdDataLoader,
            ResourceByIdDataLoader<MedicationAdministration> medicationAdministrationByIdDataLoader,
            ResourceByIdDataLoader<MedicationRequest> medicationRequestByIdDataLoader,
            ResourceByIdDataLoader<Group> groupByIdDataLoader,
            ResourceByIdDataLoader<Schedule> scheduleByIdDataLoader,
            ResourceByIdDataLoader<HealthcareService> healthServiceByIdDataLoader,
            ResourceByIdDataLoader<Organization> organizationByIdDataLoader,
            ResourceByIdDataLoader<Endpoint> endpointByIdDataLoader,
            ResourceByIdDataLoader<Encounter> encounterByIdDataLoader,
            ResourceByIdDataLoader<PractitionerRole> practitionerRoleByIdDataLoader,
            ResourceByIdDataLoader<RelatedPerson> relatedPersonByIdDataLoader,
            ResourceByIdDataLoader<DetectedIssue> detectedIssueByIdDataLoader,
            ResourceByIdDataLoader<Immunization> immunizationByIdDataLoader,
            ResourceByIdDataLoader<ImmunizationRecommendation> immunizationRecommendationByIdDataLoader,
            ResourceByIdDataLoader<MedicationDispense> medicationDispenseByIdDataLoader,
            ResourceByIdDataLoader<MedicationStatement> medicationStatementByIdDataLoader,
            ResourceByIdDataLoader<Observation> observationByIdDataLoader,
            ResourceByIdDataLoader<Procedure> procedureByIdDataLoader,
            ResourceByIdDataLoader<QuestionnaireResponse> questionnaireResponseByIdDataLoader,
            ResourceByIdDataLoader<Questionnaire> questionnaireByIdDataLoader,
            ResourceByIdDataLoader<Specimen> specimenByIdDataLoader,
            ResourceByIdDataLoader<Substance> substanceByIdDataLoader,
            ResourceByIdDataLoader<AllergyIntolerance> allergyIntoleranceByIdDataLoader,
            ResourceByIdDataLoader<CarePlan> carePlanByIdDataLoader,
            ResourceByIdDataLoader<CareTeam> careTeamByIdDataLoader,
            ResourceByIdDataLoader<Claim> claimByIdDataLoader,
            ResourceByIdDataLoader<ClaimResponse> claimResponseByIdDataLoader,
            ResourceByIdDataLoader<Communication> communicationByIdDataLoader,
            ResourceByIdDataLoader<CommunicationRequest> communicationRequestByIdDataLoader,
            ResourceByIdDataLoader<Composition> compositionByIdDataLoader,
            ResourceByIdDataLoader<Consent> consentByIdDataLoader,
            ResourceByIdDataLoader<Contract> contractByIdDataLoader,
            ResourceByIdDataLoader<DeviceRequest> deviceRequestByIdDataLoader,
            ResourceByIdDataLoader<DeviceUseStatement> deviceUseStatementByIdDataLoader,
            ResourceByIdDataLoader<EnrollmentRequest> enrollmentRequestByIdDataLoader,
            ResourceByIdDataLoader<EnrollmentResponse> enrollmentResponseByIdDataLoader,
            ResourceByIdDataLoader<EpisodeOfCare> episodeOfCareByIdDataLoader,
            ResourceByIdDataLoader<ExplanationOfBenefit> explanationOfBenefitByIdDataLoader,
            ResourceByIdDataLoader<FamilyMemberHistory> familyMemberHistoryByIdDataLoader,
            ResourceByIdDataLoader<Flag> flagByIdDataLoader,
            ResourceByIdDataLoader<Goal> goalByIdDataLoader,
            ResourceByIdDataLoader<ImagingStudy> imagingStudyByIdDataLoader,
            ResourceByIdDataLoader<Library> libraryByIdDataLoader,
            ResourceByIdDataLoader<List> listByIdDataLoader,
            ResourceByIdDataLoader<Measure> measureByIdDataLoader,
            ResourceByIdDataLoader<MeasureReport> measureReportByIdDataLoader,
            ResourceByIdDataLoader<Media> mediaByIdDataLoader,
            ResourceByIdDataLoader<MedicationKnowledge> medicationKnowledgeByIdDataLoader,
            ResourceByIdDataLoader<DiagnosticReport> diagnosticReportByIdDataLoader,
            ResourceByIdDataLoader<TestReport> testReportByIdDataLoader,
            ResourceByIdDataLoader<TestScript> testScriptByIdDataLoader,
            ResourceByIdDataLoader<ImmunizationEvaluation> immunizationEvaluationByIdDataLoader,
            ResourceByIdDataLoader<ImplementationGuide> implementationGuideByIdDataLoader,
            ResourceByIdDataLoader<Linkage> linkageByIdDataLoader,
            ResourceByIdDataLoader<NutritionOrder> nutritionOrderByIdDataLoader,
            ResourceByIdDataLoader<PaymentNotice> paymentNoticeByIdDataLoader,
            ResourceByIdDataLoader<PaymentReconciliation> paymentReconciliationByIdDataLoader,
            ResourceByIdDataLoader<Person> personByIdDataLoader,
            ResourceByIdDataLoader<PlanDefinition> planDefinitionByIdDataLoader,
            ResourceByIdDataLoader<ServiceRequest> serviceRequestByIdDataLoader,
            ResourceByIdDataLoader<Task> taskByIdDataLoader
        )
        {
            AccountByIdDataLoader = accountByIdDataLoader;
            AppointmentByIdDataLoader = appointmentByIdDataLoader;
            PatientByIdDataLoader = patientByIdDataLoader;
            PractitionerByIdDataLoader = practitionerByIdDataLoader;
            LocationByIdDataLoader = locationByIdDataLoader;
            ConditionByIdDataLoader = conditionByIdDataLoader;
            CoverageByIdDataLoader = coverageByIdDataLoader;
            DeviceByIdDataLoader = deviceByIdDataLoader;
            DeviceDefinitionByIdDataLoader = deviceDefinitionByIdDataLoader;
            ProvenanceByIdDataLoader = provenanceByIdDataLoader;
            SlotByIdDataLoader = slotByIdDataLoader;
            MedicationByIdDataLoader = medicationByIdDataLoader;
            MedicationAdministrationByIdDataLoader = medicationAdministrationByIdDataLoader;
            MedicationRequestByIdDataLoader = medicationRequestByIdDataLoader;
            GroupByIdDataLoader = groupByIdDataLoader;
            ScheduleByIdDataLoader = scheduleByIdDataLoader;
            HealthServiceByIdDataLoader = healthServiceByIdDataLoader;
            OrganizationByIdDataLoader = organizationByIdDataLoader;
            EndpointByIdDataLoader = endpointByIdDataLoader;
            EncounterByIdDataLoader = encounterByIdDataLoader;
            PractitionerRoleByIdDataLoader = practitionerRoleByIdDataLoader;
            RelatedPersonByIdDataLoader = relatedPersonByIdDataLoader;
            DetectedIssueByIdDataLoader = detectedIssueByIdDataLoader;
            ImmunizationByIdDataLoader = immunizationByIdDataLoader;
            ImmunizationRecommendationByIdDataLoader = immunizationRecommendationByIdDataLoader;
            MedicationDispenseByIdDataLoader = medicationDispenseByIdDataLoader;
            MedicationStatementByIdDataLoader = medicationStatementByIdDataLoader;
            ObservationByIdDataLoader = observationByIdDataLoader;
            ProcedureByIdDataLoader = procedureByIdDataLoader;
            QuestionnaireResponseByIdDataLoader = questionnaireResponseByIdDataLoader;
            QuestionnaireByIdDataLoader = questionnaireByIdDataLoader;
            SpecimenByIdDataLoader = specimenByIdDataLoader;
            SubstanceByIdDataLoader = substanceByIdDataLoader;
            AllergyIntoleranceByIdDataLoader = allergyIntoleranceByIdDataLoader;
            CarePlanByIdDataLoader = carePlanByIdDataLoader;
            CareTeamByIdDataLoader = careTeamByIdDataLoader;
            ClaimByIdDataLoader = claimByIdDataLoader;
            ClaimResponseByIdDataLoader = claimResponseByIdDataLoader;
            CommunicationByIdDataLoader = communicationByIdDataLoader;
            CommunicationRequestByIdDataLoader = communicationRequestByIdDataLoader;
            CompositionByIdDataLoader = compositionByIdDataLoader;
            ConsentByIdDataLoader = consentByIdDataLoader;
            ContractByIdDataLoader = contractByIdDataLoader;
            DeviceRequestByIdDataLoader = deviceRequestByIdDataLoader;
            DeviceUseStatementByIdDataLoader = deviceUseStatementByIdDataLoader;
            EnrollmentRequestByIdDataLoader = enrollmentRequestByIdDataLoader;
            EnrollmentResponseByIdDataLoader = enrollmentResponseByIdDataLoader;
            EpisodeOfCareByIdDataLoader = episodeOfCareByIdDataLoader;
            ExplanationOfBenefitByIdDataLoader = explanationOfBenefitByIdDataLoader;
            FamilyMemberHistoryByIdDataLoader = familyMemberHistoryByIdDataLoader;
            FlagByIdDataLoader = flagByIdDataLoader;
            GoalByIdDataLoader = goalByIdDataLoader;
            ImagingStudyByIdDataLoader = imagingStudyByIdDataLoader;
            LibraryByIdDataLoader = libraryByIdDataLoader;
            ListByIdDataLoader = listByIdDataLoader;
            MeasureByIdDataLoader = measureByIdDataLoader;
            MeasureReportByIdDataLoader = measureReportByIdDataLoader;
            MediaByIdDataLoader = mediaByIdDataLoader;
            MedicationKnowledgeByIdDataLoader = medicationKnowledgeByIdDataLoader;
            DiagnosticReportByIdDataLoader = diagnosticReportByIdDataLoader;
            TestReportByIdDataLoader = testReportByIdDataLoader;
            TestScriptByIdDataLoader = testScriptByIdDataLoader;
            ImmunizationEvaluationByIdDataLoader = immunizationEvaluationByIdDataLoader;
            ImplementationGuideByIdDataLoader = implementationGuideByIdDataLoader;
            LinkageByIdDataLoader = linkageByIdDataLoader;
            NutritionOrderByIdDataLoader = nutritionOrderByIdDataLoader;
            PaymentNoticeByIdDataLoader = paymentNoticeByIdDataLoader;
            PaymentReconciliationByIdDataLoader = paymentReconciliationByIdDataLoader;
            PersonByIdDataLoader = personByIdDataLoader;
            PlanDefinitionByIdDataLoader = planDefinitionByIdDataLoader;
            ServiceRequestByIdDataLoader = serviceRequestByIdDataLoader;
            TaskByIdDataLoader = taskByIdDataLoader;
        }

        public ResourceByIdDataLoader<Account> AccountByIdDataLoader { get; }
        public ResourceByIdDataLoader<Appointment> AppointmentByIdDataLoader { get; }
        public ResourceByIdDataLoader<Patient> PatientByIdDataLoader { get; }
        public ResourceByIdDataLoader<Practitioner> PractitionerByIdDataLoader { get; }
        public ResourceByIdDataLoader<Location> LocationByIdDataLoader { get; }
        public ResourceByIdDataLoader<Condition> ConditionByIdDataLoader { get; }
        public ResourceByIdDataLoader<Coverage> CoverageByIdDataLoader { get; }
        public ResourceByIdDataLoader<Device> DeviceByIdDataLoader { get; }
        public ResourceByIdDataLoader<DeviceDefinition> DeviceDefinitionByIdDataLoader { get; }
        public ResourceByIdDataLoader<Provenance> ProvenanceByIdDataLoader { get; }
        public ResourceByIdDataLoader<Slot> SlotByIdDataLoader { get; }
        public ResourceByIdDataLoader<Medication> MedicationByIdDataLoader { get; }
        public ResourceByIdDataLoader<MedicationAdministration> MedicationAdministrationByIdDataLoader { get; }
        public ResourceByIdDataLoader<MedicationRequest> MedicationRequestByIdDataLoader { get; }
        public ResourceByIdDataLoader<Group> GroupByIdDataLoader { get; }
        public ResourceByIdDataLoader<Schedule> ScheduleByIdDataLoader { get; }
        public ResourceByIdDataLoader<HealthcareService> HealthServiceByIdDataLoader { get; }
        public ResourceByIdDataLoader<Organization> OrganizationByIdDataLoader { get; }
        public ResourceByIdDataLoader<Endpoint> EndpointByIdDataLoader { get; }
        public ResourceByIdDataLoader<Encounter> EncounterByIdDataLoader { get; }
        public ResourceByIdDataLoader<PractitionerRole> PractitionerRoleByIdDataLoader { get; }
        public ResourceByIdDataLoader<RelatedPerson> RelatedPersonByIdDataLoader { get; }
        public ResourceByIdDataLoader<DetectedIssue> DetectedIssueByIdDataLoader { get; }
        public ResourceByIdDataLoader<Immunization> ImmunizationByIdDataLoader { get; }
        public ResourceByIdDataLoader<ImmunizationRecommendation> ImmunizationRecommendationByIdDataLoader { get; }
        public ResourceByIdDataLoader<MedicationDispense> MedicationDispenseByIdDataLoader { get; }
        public ResourceByIdDataLoader<MedicationStatement> MedicationStatementByIdDataLoader { get; }
        public ResourceByIdDataLoader<Observation> ObservationByIdDataLoader { get; }
        public ResourceByIdDataLoader<Procedure> ProcedureByIdDataLoader { get; }
        public ResourceByIdDataLoader<QuestionnaireResponse> QuestionnaireResponseByIdDataLoader { get; }
        public ResourceByIdDataLoader<Questionnaire> QuestionnaireByIdDataLoader { get; }
        public ResourceByIdDataLoader<Specimen> SpecimenByIdDataLoader { get; }
        public ResourceByIdDataLoader<Substance> SubstanceByIdDataLoader { get; }
        public ResourceByIdDataLoader<AllergyIntolerance> AllergyIntoleranceByIdDataLoader { get; }
        public ResourceByIdDataLoader<CarePlan> CarePlanByIdDataLoader { get; }
        public ResourceByIdDataLoader<CareTeam> CareTeamByIdDataLoader { get; }
        public ResourceByIdDataLoader<Claim> ClaimByIdDataLoader { get; }
        public ResourceByIdDataLoader<ClaimResponse> ClaimResponseByIdDataLoader { get; }
        public ResourceByIdDataLoader<Communication> CommunicationByIdDataLoader { get; }
        public ResourceByIdDataLoader<CommunicationRequest> CommunicationRequestByIdDataLoader { get; }
        public ResourceByIdDataLoader<Composition> CompositionByIdDataLoader { get; }
        public ResourceByIdDataLoader<Consent> ConsentByIdDataLoader { get; }
        public ResourceByIdDataLoader<Contract> ContractByIdDataLoader { get; }
        public ResourceByIdDataLoader<DeviceRequest> DeviceRequestByIdDataLoader { get; }
        public ResourceByIdDataLoader<DeviceUseStatement> DeviceUseStatementByIdDataLoader { get; }
        public ResourceByIdDataLoader<EnrollmentRequest> EnrollmentRequestByIdDataLoader { get; }
        public ResourceByIdDataLoader<EnrollmentResponse> EnrollmentResponseByIdDataLoader { get; }
        public ResourceByIdDataLoader<EpisodeOfCare> EpisodeOfCareByIdDataLoader { get; }
        public ResourceByIdDataLoader<ExplanationOfBenefit> ExplanationOfBenefitByIdDataLoader { get; }
        public ResourceByIdDataLoader<FamilyMemberHistory> FamilyMemberHistoryByIdDataLoader { get; }
        public ResourceByIdDataLoader<Flag> FlagByIdDataLoader { get; }
        public ResourceByIdDataLoader<Goal> GoalByIdDataLoader { get; }
        public ResourceByIdDataLoader<ImagingStudy> ImagingStudyByIdDataLoader { get; }
        public ResourceByIdDataLoader<Library> LibraryByIdDataLoader { get; }
        public ResourceByIdDataLoader<List> ListByIdDataLoader { get; }
        public ResourceByIdDataLoader<Measure> MeasureByIdDataLoader { get; }
        public ResourceByIdDataLoader<MeasureReport> MeasureReportByIdDataLoader { get; }
        public ResourceByIdDataLoader<Media> MediaByIdDataLoader { get; }
        public ResourceByIdDataLoader<MedicationKnowledge> MedicationKnowledgeByIdDataLoader { get; }
        public ResourceByIdDataLoader<DiagnosticReport> DiagnosticReportByIdDataLoader { get; }
        public ResourceByIdDataLoader<TestReport> TestReportByIdDataLoader { get; }
        public ResourceByIdDataLoader<TestScript> TestScriptByIdDataLoader { get; }
        public ResourceByIdDataLoader<ImmunizationEvaluation> ImmunizationEvaluationByIdDataLoader { get; }
        public ResourceByIdDataLoader<ImplementationGuide> ImplementationGuideByIdDataLoader { get; }
        public ResourceByIdDataLoader<Linkage> LinkageByIdDataLoader { get; }
        public ResourceByIdDataLoader<NutritionOrder> NutritionOrderByIdDataLoader { get; }
        public ResourceByIdDataLoader<PaymentNotice> PaymentNoticeByIdDataLoader { get; }
        public ResourceByIdDataLoader<PaymentReconciliation> PaymentReconciliationByIdDataLoader { get; }
        public ResourceByIdDataLoader<Person> PersonByIdDataLoader { get; }
        public ResourceByIdDataLoader<PlanDefinition> PlanDefinitionByIdDataLoader { get; }
        public ResourceByIdDataLoader<ServiceRequest> ServiceRequestByIdDataLoader { get; }
        public ResourceByIdDataLoader<Task> TaskByIdDataLoader { get; }
    }
}