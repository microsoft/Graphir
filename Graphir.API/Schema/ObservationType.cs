using Hl7.Fhir.Model;

using HotChocolate.Types;

using static Hl7.Fhir.Model.Observation;

namespace Graphir.API.Schema;

public class ObservationType : ObjectType<Observation>
{
    protected override void Configure(IObjectTypeDescriptor<Observation> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Meta);
        descriptor.Field(x => x.ImplicitRules);
        descriptor.Field(x => x.Language);
        descriptor.Field(x => x.Text);
        descriptor.Field(x => x.Contained);
        descriptor.Field(x => x.Extension);
        descriptor.Field(x => x.ModifierExtension);
        descriptor.Field(x => x.Identifier);
        descriptor.Field(x => x.Interpretation);
        descriptor.Field(x => x.BasedOn).Type<ListType<ResourceReferenceType<ObservationBasedOnType>>>();
        descriptor.Field(x => x.PartOf).Type<ListType<ResourceReferenceType<ObservationPartOfType>>>();
        descriptor.Field(x => x.Status);
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Code);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<ObservationSubjectType>>();
        descriptor.Field(x => x.Focus).Type<ListType<ResourceReferenceType<ObservationFocusType>>>();
        descriptor.Field(x => x.Encounter).Type<ResourceReferenceType<ObservationEncounterType>>();
        descriptor.Field(x => x.Method);
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.Performer).Type<ListType<ResourceReferenceType<ObservationPerformerType>>>();
        descriptor.Field(x => x.Specimen).Type<ResourceReferenceType<ObservationSpecimenType>>();
        descriptor.Field(x => x.Issued);
        // descriptor.Field(x => x.Value);
        descriptor.Field(x => x.BodySite);
        descriptor.Field(x => x.DerivedFrom).Type<ListType<ResourceReferenceType<ObservationDerivedFromType>>>();
        descriptor.Field(x => x.HasMember).Type<ListType<ResourceReferenceType<ObservationHasMemberType>>>();
        descriptor.Field(x => x.IssuedElement);
        descriptor.Field(x => x.ReferenceRange).Type<ListType<ReferenceRangeComponentType>>();
        descriptor.Field(x => x.StatusElement).Type<StringType>(); // Should specify as StringType
        descriptor.Field(x => x.TypeName);
        descriptor.Field(x => x.DataAbsentReason);
        descriptor.Field(x => x.HasVersionId);
        descriptor.Field(x => x.VersionId);
        // descriptor.Field(x => x.Effective);
        descriptor.Field(x => x.Device).Type<ResourceReferenceType<ObservationDeviceType>>();
        descriptor.Field(x => x.Component).Type<ListType<ComponentComponentType>>();
        
    }
}

public class ComponentComponentType : ObjectType<ComponentComponent>
{
  protected override void Configure(IObjectTypeDescriptor<ComponentComponent> descriptor)
  {
      descriptor.BindFieldsExplicitly();
      descriptor.Field(x => x.Code);
      descriptor.Field(x => x.DataAbsentReason);
      descriptor.Field(x => x.Interpretation);
      descriptor.Field(x => x.ReferenceRange).Type<ListType<ReferenceRangeComponentType>>();
      //descriptor.Field(x => x.Value);
      
  }
}

public class ObservationDeviceType : UnionType
{
  protected override void Configure(IUnionTypeDescriptor descriptor)
  {
      descriptor.Name("ObservationDeviceType");
      
      descriptor.Type<DeviceType>();
      // descriptor.Type<DeviceMetricType>();
  }
}

public class ReferenceRangeComponentType : ObjectType<ReferenceRangeComponent>
{
    /*
     public class ReferenceRangeComponent : BackboneElement
    {
      private Quantity _Low;
      private Quantity _High;
      private CodeableConcept _Type;
      private List<CodeableConcept> _AppliesTo;
      private Range _Age;
      private FhirString _TextElement;

      /// <summary>FHIR Type Name</summary>
      public override string TypeName => "Observation#ReferenceRange";

      /// <summary>Low Range, if relevant</summary>
      [FhirElement("low", Order = 40)]
      [DataMember]
      public Quantity Low
      {
        get => this._Low;
        set
        {
          this._Low = value;
          this.OnPropertyChanged(nameof (Low));
        }
      }

      /// <summary>High Range, if relevant</summary>
      [FhirElement("high", Order = 50)]
      [DataMember]
      public Quantity High
      {
        get => this._High;
        set
        {
          this._High = value;
          this.OnPropertyChanged(nameof (High));
        }
      }

      /// <summary>Reference range qualifier</summary>
      [FhirElement("type", Order = 60)]
      [DataMember]
      public CodeableConcept Type
      {
        get => this._Type;
        set
        {
          this._Type = value;
          this.OnPropertyChanged(nameof (Type));
        }
      }

      /// <summary>Reference range population</summary>
      [FhirElement("appliesTo", Order = 70)]
      [Cardinality(Max = -1, Min = 0)]
      [DataMember]
      public List<CodeableConcept> AppliesTo
      {
        get
        {
          if (this._AppliesTo == null)
            this._AppliesTo = new List<CodeableConcept>();
          return this._AppliesTo;
        }
        set
        {
          this._AppliesTo = value;
          this.OnPropertyChanged(nameof (AppliesTo));
        }
      }

      /// <summary>Applicable age range, if relevant</summary>
      [FhirElement("age", Order = 80)]
      [DataMember]
      public Range Age
      {
        get => this._Age;
        set
        {
          this._Age = value;
          this.OnPropertyChanged(nameof (Age));
        }
      }

      /// <summary>Text based reference range in an observation</summary>
      [FhirElement("text", Order = 90)]
      [DataMember]
      public FhirString TextElement
      {
        get => this._TextElement;
        set
        {
          this._TextElement = value;
          this.OnPropertyChanged(nameof (TextElement));
        }
      }

      /// <summary>Text based reference range in an observation</summary>
      /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
      [IgnoreDataMember]
      public string Text
      {
        get => this.TextElement == null ? (string) null : this.TextElement.Value;
        set
        {
          this.TextElement = value != null ? new FhirString(value) : (FhirString) null;
          this.OnPropertyChanged(nameof (Text));
        }
      }

      public override IDeepCopyable CopyTo(IDeepCopyable other)
      {
        if (!(other is Observation.ReferenceRangeComponent other1))
          throw new ArgumentException("Can only copy to an object of the same type", nameof (other));
        base.CopyTo((IDeepCopyable) other1);
        if (this.Low != null)
          other1.Low = (Quantity) this.Low.DeepCopy();
        if (this.High != null)
          other1.High = (Quantity) this.High.DeepCopy();
        if (this.Type != null)
          other1.Type = (CodeableConcept) this.Type.DeepCopy();
        if (this.AppliesTo != null)
          other1.AppliesTo = new List<CodeableConcept>(this.AppliesTo.DeepCopy<CodeableConcept>());
        if (this.Age != null)
          other1.Age = (Range) this.Age.DeepCopy();
        if (this.TextElement != null)
          other1.TextElement = (FhirString) this.TextElement.DeepCopy();
        return (IDeepCopyable) other1;
      }

      public override IDeepCopyable DeepCopy() => this.CopyTo((IDeepCopyable) new Observation.ReferenceRangeComponent());

      /// <inheritdoc />
      public override bool Matches(IDeepComparable other) => other is Observation.ReferenceRangeComponent other1 && base.Matches((IDeepComparable) other1) && DeepComparable.Matches((IDeepComparable) this.Low, (IDeepComparable) other1.Low) && DeepComparable.Matches((IDeepComparable) this.High, (IDeepComparable) other1.High) && DeepComparable.Matches((IDeepComparable) this.Type, (IDeepComparable) other1.Type) && this.AppliesTo.Matches<CodeableConcept>((IEnumerable<CodeableConcept>) other1.AppliesTo) && DeepComparable.Matches((IDeepComparable) this.Age, (IDeepComparable) other1.Age) && DeepComparable.Matches((IDeepComparable) this.TextElement, (IDeepComparable) other1.TextElement);

      public override bool IsExactly(IDeepComparable other) => other is Observation.ReferenceRangeComponent other1 && base.IsExactly((IDeepComparable) other1) && DeepComparable.IsExactly((IDeepComparable) this.Low, (IDeepComparable) other1.Low) && DeepComparable.IsExactly((IDeepComparable) this.High, (IDeepComparable) other1.High) && DeepComparable.IsExactly((IDeepComparable) this.Type, (IDeepComparable) other1.Type) && this.AppliesTo.IsExactly<CodeableConcept>((IEnumerable<CodeableConcept>) other1.AppliesTo) && DeepComparable.IsExactly((IDeepComparable) this.Age, (IDeepComparable) other1.Age) && DeepComparable.IsExactly((IDeepComparable) this.TextElement, (IDeepComparable) other1.TextElement);

      [IgnoreDataMember]
      public override IEnumerable<Base> Children
      {
        get
        {
          foreach (Base child in base.Children)
            yield return child;
          if (this.Low != null)
            yield return (Base) this.Low;
          if (this.High != null)
            yield return (Base) this.High;
          if (this.Type != null)
            yield return (Base) this.Type;
          foreach (CodeableConcept codeableConcept in this.AppliesTo)
          {
            if (codeableConcept != null)
              yield return (Base) codeableConcept;
          }
          if (this.Age != null)
            yield return (Base) this.Age;
          if (this.TextElement != null)
            yield return (Base) this.TextElement;
        }
      }

      [IgnoreDataMember]
      public override IEnumerable<ElementValue> NamedChildren
      {
        get
        {
          foreach (ElementValue namedChild in base.NamedChildren)
            yield return namedChild;
          if (this.Low != null)
            yield return new ElementValue("low", (Base) this.Low);
          if (this.High != null)
            yield return new ElementValue("high", (Base) this.High);
          if (this.Type != null)
            yield return new ElementValue("type", (Base) this.Type);
          foreach (CodeableConcept codeableConcept in this.AppliesTo)
          {
            if (codeableConcept != null)
              yield return new ElementValue("appliesTo", (Base) codeableConcept);
          }
          if (this.Age != null)
            yield return new ElementValue("age", (Base) this.Age);
          if (this.TextElement != null)
            yield return new ElementValue("text", (Base) this.TextElement);
        }
      }
    }
     */
    protected override void Configure(IObjectTypeDescriptor<ReferenceRangeComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        
        descriptor.Field(x => x.Low);
        descriptor.Field(x => x.High);
        descriptor.Field(x => x.Type);
        descriptor.Field(x => x.AppliesTo);
        descriptor.Field(x => x.Age);
        descriptor.Field(x => x.TextElement);
        descriptor.Field(x => x.Text);
        
    }
}

public class ObservationHasMemberType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationHasMemberType");
        descriptor.Description("Related resource that belongs to the Observation group. Reference(Observation | QuestionnaireResponse | MolecularSequence)");
        
        descriptor.Type<ObservationType>();
        /* TODO: Add below types
        descriptor.Type<QuestionnaireResponseType>();
        descriptor.Type<MolecularSequenceType>();
        */
    }
}

public class ObservationDerivedFromType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationDerivedFromType");
        descriptor.Description("Related measurements the observation is made from. Reference(DocumentReference | ImagingStudy | Media | QuestionnaireResponse | Observation | MolecularSequence)");
        
        descriptor.Type<ObservationType>();
        
        /* TODO: Add below types 
        descriptor.Type<DocumentReferenceType>();
        descriptor.Type<ImagingStudyType>();
        descriptor.Type<MediaType>();
        descriptor.Type<QuestionnaireResponseType>();
        descriptor.Type<MolecularSequenceType>();
        */
        
    }
}

public class ObservationSpecimenType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationSpecimenType");
        descriptor.Description("Specimen used for this observation");
        
        descriptor.Type<SpecimenType>();
    }
}

public class ObservationPerformerType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationPerformerType");
        descriptor.Description("Who is responsible for the observation. Reference(Practitioner | PractitionerRole | Organization | CareTeam | Patient | RelatedPerson)");
        
        descriptor.Type<PractitionerType>();
        descriptor.Type<PractitionerRoleType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<PatientType>();
        descriptor.Type<RelatedPersonType>();
        // descriptor.Type<CareTeamType>(); TODO: CareTeamType is not implemented yet
        
    }
}

public class ObservationEncounterType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationEncounterType");
        descriptor.Description("Healthcare event during which this observation is made");
        
        descriptor.Type<EncounterType>();
    }
}

public class ObservationFocusType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationFocusType");
        descriptor.Description("What the observation is about, when it is not about the subject of record");
        
        descriptor.Type<ResourceType>();

    }
}

public class ObservationSubjectType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationSubjectType");
        descriptor.Description("Who and/or what the observation is about. Reference(Patient|Group|Device|Location|Organization|Procedure|Practitioner|Medication|Substance)");
        descriptor.Type<PatientType>();
        descriptor.Type<GroupType>();
        descriptor.Type<DeviceType>();
        descriptor.Type<LocationType>();
        descriptor.Type<OrganizationType>();
        descriptor.Type<PractitionerType>();
        descriptor.Type<MedicationType>();
        descriptor.Type<SubstanceType>();
        // descriptor.Type<ProcedureType>(); TODO: Add ProcedureType 

    }
}

public class ObservationPartOfType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationPartOfType");
        descriptor.Description("Part of referenced event. Reference(Procedure | Immunization | MedicationAdministration | MedicationDispense | MedicationStatement | ImagingStudy)");
        descriptor.Type<MedicationAdministrationType>();
        
        /* TODO: Add below types
        descriptor.Type<ProcedureType>();
        descriptor.Type<ImmunizationType>();
        descriptor.Type<MedicationDispenseType>();
        descriptor.Type<MedicationStatementType>();
        descriptor.Type<ImagingStudyType>();
        */
        
    }
}

public class ObservationBasedOnType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("ObservationBasedOn");
        descriptor.Description("Fulfills plan, proposal or order. Reference(CarePlan | DeviceRequest | ImmunizationRecommendation | MedicationRequest | NutritionOrder | ServiceRequest)");
        
        descriptor.Type<CarePlanType>();
        descriptor.Type<MedicationRequestType>();
        descriptor.Type<ServiceRequestType>();
        /* TODO: Add below types
        descriptor.Type<DeviceRequestType>();
        descriptor.Type<ImmunizationRecommendationType>();
        descriptor.Type<NutritionOrderType>();
        */
        
    }
}