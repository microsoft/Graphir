using Hl7.Fhir.Model;

using HotChocolate.Types;

using static Hl7.Fhir.Model.Goal;

namespace Graphir.API.Schema;

public class GoalType : ObjectType<Goal>
{
    protected override void Configure(IObjectTypeDescriptor<Goal> descriptor)
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
        descriptor.Field(x => x.LifecycleStatus);
        descriptor.Field(x => x.AchievementStatus).Type<StringType>();
        descriptor.Field(x => x.Category);
        descriptor.Field(x => x.Priority);
        descriptor.Field(x => x.Description);
        descriptor.Field(x => x.Subject).Type<ResourceReferenceType<SubjectReferenceType>>();
        // descriptor.Field(x => x.Start);   //Possible multiple types
        descriptor.Field(x => x.StatusDate);
        descriptor.Field(x => x.StatusReason);
        descriptor.Field(x => x.Target).Type<ListType<GoalTargetComponentType>>();
        descriptor.Field(x => x.ResourceBase).Type<FhirUriType>();
        descriptor.Field(x => x.Addresses).Type<ListType<ResourceReferenceType<GoalAddressesReferenceType>>>();
        descriptor.Field(x => x.Note);
        descriptor.Field(x => x.OutcomeCode);
        descriptor.Field(x => x.OutcomeReference);
    }
}

public class GoalAddressesReferenceType : UnionType
{
    protected override void Configure(IUnionTypeDescriptor descriptor)
    {
        descriptor.Name("GoalAddressesReferenceType");
        descriptor.Description(
            "Issues addressed by this goal. Reference(Condition | Observation | MedicationStatement | NutritionOrder | ServiceRequest | RiskAssessment)");

        descriptor.Type<ConditionType>();
        descriptor.Type<ServiceRequestType>();
        /* TODO: Add below types
        descriptor.Type<ObservationType>();
        descriptor.Type<MedicationStatementType>();
        descriptor.Type<NutritionOrderType>();
        descriptor.Type<RiskAssessmentType>();
        */
    }
}

public class GoalTargetComponentType : ObjectType<TargetComponent>
{
    /*
     public class TargetComponent : BackboneElement
    {
      private CodeableConcept _Measure;
      private DataType _Detail;
      private DataType _Due;

      /// <summary>FHIR Type Name</summary>
      public override string TypeName => "Goal#Target";

      /// <summary>The parameter whose value is being tracked</summary>
      [FhirElement("measure", InSummary = true, Order = 40)]
      [DataMember]
      public CodeableConcept Measure
      {
        get => this._Measure;
        set
        {
          this._Measure = value;
          this.OnPropertyChanged(nameof (Measure));
        }
      }

      /// <summary>The target value to be achieved</summary>
      [FhirElement("detail", Choice = ChoiceType.DatatypeChoice, InSummary = true, Order = 50)]
      [CLSCompliant(false)]
      [AllowedTypes(new Type[] {typeof (Quantity), typeof (Range), typeof (CodeableConcept), typeof (FhirString), typeof (FhirBoolean), typeof (Integer), typeof (Ratio)})]
      [DataMember]
      public DataType Detail
      {
        get => this._Detail;
        set
        {
          this._Detail = value;
          this.OnPropertyChanged(nameof (Detail));
        }
      }

      /// <summary>Reach goal on or before</summary>
      [FhirElement("due", Choice = ChoiceType.DatatypeChoice, InSummary = true, Order = 60)]
      [CLSCompliant(false)]
      [AllowedTypes(new Type[] {typeof (Date), typeof (Duration)})]
      [DataMember]
      public DataType Due
      {
        get => this._Due;
        set
        {
          this._Due = value;
          this.OnPropertyChanged(nameof (Due));
        }
      }

      public override IDeepCopyable CopyTo(IDeepCopyable other)
      {
        if (!(other is Goal.TargetComponent other1))
          throw new ArgumentException("Can only copy to an object of the same type", nameof (other));
        base.CopyTo((IDeepCopyable) other1);
        if (this.Measure != null)
          other1.Measure = (CodeableConcept) this.Measure.DeepCopy();
        if (this.Detail != null)
          other1.Detail = (DataType) this.Detail.DeepCopy();
        if (this.Due != null)
          other1.Due = (DataType) this.Due.DeepCopy();
        return (IDeepCopyable) other1;
      }

      public override IDeepCopyable DeepCopy() => this.CopyTo((IDeepCopyable) new Goal.TargetComponent());

      /// <inheritdoc />
      public override bool Matches(IDeepComparable other) => other is Goal.TargetComponent other1 && base.Matches((IDeepComparable) other1) && DeepComparable.Matches((IDeepComparable) this.Measure, (IDeepComparable) other1.Measure) && DeepComparable.Matches((IDeepComparable) this.Detail, (IDeepComparable) other1.Detail) && DeepComparable.Matches((IDeepComparable) this.Due, (IDeepComparable) other1.Due);

      public override bool IsExactly(IDeepComparable other) => other is Goal.TargetComponent other1 && base.IsExactly((IDeepComparable) other1) && DeepComparable.IsExactly((IDeepComparable) this.Measure, (IDeepComparable) other1.Measure) && DeepComparable.IsExactly((IDeepComparable) this.Detail, (IDeepComparable) other1.Detail) && DeepComparable.IsExactly((IDeepComparable) this.Due, (IDeepComparable) other1.Due);

      [IgnoreDataMember]
      public override IEnumerable<Base> Children
      {
        get
        {
          foreach (Base child in base.Children)
            yield return child;
          if (this.Measure != null)
            yield return (Base) this.Measure;
          if (this.Detail != null)
            yield return (Base) this.Detail;
          if (this.Due != null)
            yield return (Base) this.Due;
        }
      }

      [IgnoreDataMember]
      public override IEnumerable<ElementValue> NamedChildren
      {
        get
        {
          foreach (ElementValue namedChild in base.NamedChildren)
            yield return namedChild;
          if (this.Measure != null)
            yield return new ElementValue("measure", (Base) this.Measure);
          if (this.Detail != null)
            yield return new ElementValue("detail", (Base) this.Detail);
          if (this.Due != null)
            yield return new ElementValue("due", (Base) this.Due);
        }
      }
    }
     */
    protected override void Configure(IObjectTypeDescriptor<TargetComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Measure);
        // descriptor.Field(x => x.Detail); //Possible multiple types
        // descriptor.Field(x => x.Due); //Possible multiple types
    }
}