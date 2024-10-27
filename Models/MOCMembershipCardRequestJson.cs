/*
 * MOCMembershipCardRequestJSon.cs
 *     Created: 2024-10-27T03:35:22-04:00
 *    Modified: 2024-10-27T03:35:22-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 © 2024 Dr. David Gerard, All Rights Reserved, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace QuickType
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MocMembershipCardRequest
    {
        [JsonProperty(nameof(FirstName))]
        public string FirstName { get; set; }

        [JsonProperty(nameof(LastName))]
        public string LastName { get; set; }

        [JsonProperty(nameof(Email))]
        public string Email { get; set; }

        [JsonProperty(nameof(DisplayName))]
        public string DisplayName { get; set; }

        [JsonProperty(nameof(Organization))]
        public string Organization { get; set; }

        [JsonProperty(nameof(ProfileLastUpdated))]
        public DateTimeOffset ProfileLastUpdated { get; set; }

        [JsonProperty(nameof(MembershipLevel))]
        public MembershipLevel MembershipLevel { get; set; }

        [JsonProperty(nameof(MembershipEnabled))]
        public bool MembershipEnabled { get; set; }

        [JsonProperty(nameof(Status))]
        public string Status { get; set; }

        [JsonProperty(nameof(FieldValues))]
        public FieldValue[] FieldValues { get; set; }

        [JsonProperty(nameof(Id))]
        public long Id { get; set; }

        [JsonProperty(nameof(Url))]
        public Uri Url { get; set; }

        [JsonProperty(nameof(IsAccountAdministrator))]
        public bool IsAccountAdministrator { get; set; }

        [JsonProperty(nameof(TermsOfUseAccepted))]
        public bool TermsOfUseAccepted { get; set; }

        [JsonProperty(nameof(Fields))]
        public Fields Fields { get; set; }

        [JsonProperty(nameof(AccessToProfileByOthers))]
        public bool AccessToProfileByOthers { get; set; }

        [JsonProperty(nameof(Balance))]
        public long Balance { get; set; }

        [JsonProperty(nameof(BundleId))]
        public object BundleId { get; set; }

        [JsonProperty(nameof(EmailDisabled))]
        public bool EmailDisabled { get; set; }

        [JsonProperty(nameof(Groups))]
        public string[] Groups { get; set; }

        [JsonProperty(nameof(IsArchived))]
        public bool IsArchived { get; set; }

        [JsonProperty(nameof(IsDonor))]
        public bool IsDonor { get; set; }

        [JsonProperty(nameof(IsEventAttendee))]
        public bool IsEventAttendee { get; set; }

        [JsonProperty(nameof(IsMember))]
        public bool IsMember { get; set; }

        [JsonProperty(nameof(MemberId))]
        public DateTimeOffset MemberId { get; set; }

        [JsonProperty(nameof(MemberSince))]
        public DateTimeOffset MemberSince { get; set; }

        [JsonProperty(nameof(Notes))]
        public string Notes { get; set; }

        [JsonProperty(nameof(Phone))]
        public Phone Phone { get; set; }

        [JsonProperty(nameof(ReceiveEventReminders))]
        public bool ReceiveEventReminders { get; set; }

        [JsonProperty(nameof(ReceiveNewsletters))]
        public DateTimeOffset ReceiveNewsletters { get; set; }

        [JsonProperty(nameof(RecievingEMailsDisabled))]
        public bool RecievingEMailsDisabled { get; set; }

        [JsonProperty(nameof(RenewalDue))]
        public DateTimeOffset RenewalDue { get; set; }

        [JsonProperty(nameof(HasAcceptedPrivacyPolicy))]
        public bool HasAcceptedPrivacyPolicy { get; set; }

        [JsonProperty(nameof(DateOfBirth))]
        public DateTimeOffset DateOfBirth { get; set; }

        [JsonProperty(nameof(MarketPosition))]
        public string[] MarketPosition { get; set; }

        [JsonProperty(nameof(HasAcceptedClubRules))]
        public bool HasAcceptedClubRules { get; set; }
    }

    public partial class FieldValue
    {
        [JsonProperty(nameof(FieldName))]
        public string FieldName { get; set; }

        [JsonProperty(nameof(Value))]
        public ValueUnion Value { get; set; }

        [JsonProperty(nameof(SystemCode))]
        public string SystemCode { get; set; }
    }

    public partial class ValueElement
    {
        [JsonProperty(nameof(Id))]
        public long Id { get; set; }

        [JsonProperty(nameof(Label))]
        public string Label { get; set; }
    }

    public partial class PurpleValue
    {
        [JsonProperty(nameof(Id))]
        public long Id { get; set; }

        [JsonProperty(nameof(Label))]
        public string Label { get; set; }

        [JsonProperty(nameof(Value))]
        public string Value { get; set; }

        [JsonProperty(nameof(SelectedByDefault))]
        public bool SelectedByDefault { get; set; }

        [JsonProperty(nameof(Position))]
        public long Position { get; set; }
    }

    public partial class Fields
    {
        [JsonProperty(nameof(AccessToProfileByOthers))]
        public bool AccessToProfileByOthers { get; set; }

        [JsonProperty(nameof(Balance))]
        public long Balance { get; set; }

        [JsonProperty(nameof(BundleId))]
        public object BundleId { get; set; }

        [JsonProperty(nameof(EmailDisabled))]
        public bool EmailDisabled { get; set; }

        [JsonProperty(nameof(Groups))]
        public string[] Groups { get; set; }

        [JsonProperty(nameof(IsArchived))]
        public bool IsArchived { get; set; }

        [JsonProperty(nameof(IsDonor))]
        public bool IsDonor { get; set; }

        [JsonProperty(nameof(IsEventAttendee))]
        public bool IsEventAttendee { get; set; }

        [JsonProperty(nameof(IsMember))]
        public bool IsMember { get; set; }

        [JsonProperty(nameof(MemberId))]
        public DateTimeOffset MemberId { get; set; }

        [JsonProperty(nameof(MemberSince))]
        public DateTimeOffset MemberSince { get; set; }

        [JsonProperty(nameof(Notes))]
        public string Notes { get; set; }

        [JsonProperty(nameof(Phone))]
        public Phone Phone { get; set; }

        [JsonProperty(nameof(ReceiveEventReminders))]
        public bool ReceiveEventReminders { get; set; }

        [JsonProperty(nameof(ReceiveNewsletters))]
        public DateTimeOffset ReceiveNewsletters { get; set; }

        [JsonProperty(nameof(RecievingEMailsDisabled))]
        public bool RecievingEMailsDisabled { get; set; }

        [JsonProperty(nameof(RenewalDue))]
        public DateTimeOffset RenewalDue { get; set; }

        [JsonProperty(nameof(HasAcceptedPrivacyPolicy))]
        public bool HasAcceptedPrivacyPolicy { get; set; }

        [JsonProperty(nameof(DateOfBirth))]
        public DateTimeOffset DateOfBirth { get; set; }

        [JsonProperty(nameof(MarketPosition))]
        public string[] MarketPosition { get; set; }

        [JsonProperty(nameof(HasAcceptedClubRules))]
        public bool HasAcceptedClubRules { get; set; }
    }

    public partial class Phone
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCallingCode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CountryCallingCode { get; set; }

        [JsonProperty("nationalNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NationalNumber { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }

    public partial class MembershipLevel
    {
        [JsonProperty(nameof(Id))]
        public long Id { get; set; }

        [JsonProperty(nameof(Url))]
        public Uri Url { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }
    }

    public partial struct ValueUnion
    {
        public static implicit operator ValueUnion(bool Bool) => new ValueUnion { Bool = Bool };

        public static implicit operator ValueUnion(long Integer) =>
            new ValueUnion { Integer = Integer };

        public static implicit operator ValueUnion(PurpleValue PurpleValue) =>
            new ValueUnion { PurpleValue = PurpleValue };

        public static implicit operator ValueUnion(string String) =>
            new ValueUnion { String = String };

        public static implicit operator ValueUnion(ValueElement[] ValueElementArray) =>
            new ValueUnion { ValueElementArray = ValueElementArray };

        public bool IsNull =>
            ValueElementArray == null
            && Bool == null
            && PurpleValue == null
            && Integer == null
            && String == null;

        public bool? Bool { get; set; }
        public long? Integer { get; set; }
        public PurpleValue PurpleValue { get; set; }
        public string String { get; set; }
        public ValueElement[] ValueElementArray { get; set; }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ValueUnionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
            },
        };
    }

    internal class ValueUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) =>
            t == typeof(ValueUnion) || t == typeof(ValueUnion?);

        public override object ReadJson(
            JsonReader reader,
            Type t,
            object existingValue,
            JsonSerializer serializer
        )
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new ValueUnion { };
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new ValueUnion { Integer = integerValue };
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new ValueUnion { Bool = boolValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new ValueUnion { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PurpleValue>(reader);
                    return new ValueUnion { PurpleValue = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<ValueElement[]>(reader);
                    return new ValueUnion { ValueElementArray = arrayValue };
            }
            throw new TypeInitializationException("Cannot unmarshal type ValueUnion", null);
        }

        public override void WriteJson(
            JsonWriter writer,
            object untypedValue,
            JsonSerializer serializer
        )
        {
            var value = (ValueUnion)untypedValue;
            if (value.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Bool != null)
            {
                serializer.Serialize(writer, value.Bool.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.ValueElementArray != null)
            {
                serializer.Serialize(writer, value.ValueElementArray);
                return;
            }
            if (value.PurpleValue != null)
            {
                serializer.Serialize(writer, value.PurpleValue);
                return;
            }
            throw new TypeInitializationException("Cannot marshal type ValueUnion", null);
        }

        public static readonly ValueUnionConverter Singleton = new ValueUnionConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(
            JsonReader reader,
            Type t,
            object existingValue,
            JsonSerializer serializer
        )
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(
            JsonWriter writer,
            object untypedValue,
            JsonSerializer serializer
        )
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
