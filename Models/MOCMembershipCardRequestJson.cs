/*
 * MOCMembershipCardRequestJSon.cs
 *     Created: 2024-10-27T03:35:22-04:00
 *    Modified: 2024-10-27T03:35:22-04:00
 *      Author: Dr. David Gerard <david@mymoc.social>
 *   Copyright: © 2022 - 2024 © 2024 Dr. David Gerard, All Rights Reserved, All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace MOCSocialClubPassWebService.Models.Json
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MocMembershipCardRequest
    {
        [JsonProperty(nameof(FirstName))]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty(nameof(LastName))]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty(nameof(Email))]
        public string Email { get; set; } = string.Empty;

        [JsonProperty(nameof(DisplayName))]
        public string DisplayName { get; set; } = string.Empty;

        [JsonProperty(nameof(Organization))]
        public string Organization { get; set; } = string.Empty;

        [JsonProperty(nameof(ProfileLastUpdated))]
        public DateTimeOffset ProfileLastUpdated { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(MembershipLevel))]
        public MembershipLevel MembershipLevel { get; set; } = new MembershipLevel();

        [JsonProperty(nameof(MembershipEnabled))]
        public bool MembershipEnabled { get; set; } = false;

        [JsonProperty(nameof(Status))]
        public string Status { get; set; } = string.Empty;

        // [JsonProperty(nameof(FieldValues))]
        // public FieldValue[] FieldValues { get; set; } = Array.Empty<FieldValue>();

        [JsonProperty(nameof(Id))]
        public long Id { get; set; } = 0;

        [JsonProperty(nameof(Url))]
        [JsonConverter<JsonUriStringConverter>]
        public Uri Url { get; set; } = new Uri("http://example.com");

        [JsonProperty(nameof(IsAccountAdministrator))]
        public bool IsAccountAdministrator { get; set; } = false;

        [JsonProperty(nameof(TermsOfUseAccepted))]
        public bool TermsOfUseAccepted { get; set; } = false;

        [JsonProperty(nameof(Fields))]
        public Fields Fields { get; set; } = new Fields();

        [JsonProperty(nameof(AccessToProfileByOthers))]
        public bool AccessToProfileByOthers { get; set; } = false;

        [JsonProperty(nameof(Balance))]
        public long Balance { get; set; } = 0;

        // [JsonProperty(nameof(BundleId))]
        // public object BundleId { get; set; } = new object();

        [JsonProperty(nameof(EmailDisabled))]
        public bool EmailDisabled { get; set; } = false;

        [JsonProperty(nameof(Groups))]
        public string[] Groups { get; set; } = Array.Empty<string>();

        [JsonProperty(nameof(IsArchived))]
        public bool IsArchived { get; set; } = false;

        [JsonProperty(nameof(IsDonor))]
        public bool IsDonor { get; set; } = false;

        [JsonProperty(nameof(IsEventAttendee))]
        public bool IsEventAttendee { get; set; } = false;

        [JsonProperty(nameof(IsMember))]
        public bool IsMember { get; set; } = false;

        [JsonProperty(nameof(MemberId))]
        public DateTimeOffset MemberId { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(MemberSince))]
        public DateTimeOffset MemberSince { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(Notes))]
        public string Notes { get; set; } = string.Empty;

        [JsonProperty(nameof(Phone))]
        public Phone Phone { get; set; } = new Phone();

        [JsonProperty(nameof(ReceiveEventReminders))]
        public bool ReceiveEventReminders { get; set; } = false;

        [JsonProperty(nameof(ReceiveNewsletters))]
        public DateTimeOffset ReceiveNewsletters { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(RecievingEMailsDisabled))]
        public bool RecievingEMailsDisabled { get; set; } = false;

        [JsonProperty(nameof(RenewalDue))]
        public DateTimeOffset RenewalDue { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(HasAcceptedPrivacyPolicy))]
        public bool HasAcceptedPrivacyPolicy { get; set; } = false;

        [JsonProperty(nameof(DateOfBirth))]
        public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(MarketPosition))]
        public string[] MarketPosition { get; set; } = Array.Empty<string>();

        [JsonProperty(nameof(HasAcceptedClubRules))]
        public bool HasAcceptedClubRules { get; set; } = false;

        [JsonProperty(nameof(Avatar))]
        public PhotoUrl Avatar { get; set; } = Constants.Defaults.UnknownAvatarUri;

        public string OutputFilename { get; set; } = Constants.DefaultFilename;
    }

    [JsonConverter<PhotoUrlJsonConverter>]
    public class PhotoUrl(string url)
    {
        [JsonProperty(nameof(Value))]
        [JsonConverter<JsonUriStringConverter>]
        public Uri Value { get; set; } =
            Uri.TryCreate(url, UriKind.Absolute, out var uri) ? uri : new Uri("about:blank");

        public static implicit operator PhotoUrl(Uri url) => new(url.ToString());

        public static implicit operator PhotoUrl(string url) => new(url);

        public static implicit operator string(PhotoUrl url) => url.Value.ToString();

        public override string ToString() => Value.ToString();

        public override bool Equals(object obj) => Value.Equals(obj);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(PhotoUrl left, PhotoUrl right) => left.Equals(right);

        public static bool operator !=(PhotoUrl left, PhotoUrl right) => !(left == right);

        public virtual async Task<byte[]> GetBytesAsync(HttpClient httpClient) =>
            await httpClient.GetByteArrayAsync(Value);
    }

    public class PhotoUrlJsonConverter : System.Text.Json.Serialization.JsonConverter<PhotoUrl>
    {
        public override PhotoUrl Read(ref Utf8JsonReader reader, type typeToConvert, Jso options) =>
            new(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, PhotoUrl value, Jso options) =>
            writer.WriteStringValue(value.Value.ToString());
    }

    public partial class FieldValue
    {
        [JsonProperty(nameof(FieldName))]
        public string FieldName { get; set; } = string.Empty;

        [JsonProperty(nameof(Value))]
        public ValueUnion Value { get; set; } = new ValueUnion();

        [JsonProperty(nameof(SystemCode))]
        public string SystemCode { get; set; } = string.Empty;
    }

    public partial class ValueElement
    {
        [JsonProperty(nameof(Id))]
        public long Id { get; set; } = 0;

        [JsonProperty(nameof(Label))]
        public string Label { get; set; } = string.Empty;
    }

    public partial class PurpleValue
    {
        [JsonProperty(nameof(Id))]
        public long Id { get; set; } = 0;

        [JsonProperty(nameof(Label))]
        public string Label { get; set; } = string.Empty;

        [JsonProperty(nameof(Value))]
        public string Value { get; set; } = string.Empty;

        [JsonProperty(nameof(SelectedByDefault))]
        public bool SelectedByDefault { get; set; } = false;

        [JsonProperty(nameof(Position))]
        public long Position { get; set; } = 0;
    }

    public partial class Fields
    {
        [JsonProperty(nameof(AccessToProfileByOthers))]
        public bool AccessToProfileByOthers { get; set; } = false;

        [JsonProperty(nameof(Balance))]
        public long Balance { get; set; } = 0;

        // [JsonProperty(nameof(BundleId))]
        // public object BundleId { get; set; } = new object();

        [JsonProperty(nameof(EmailDisabled))]
        public bool EmailDisabled { get; set; } = false;

        [JsonProperty(nameof(Groups))]
        public string[] Groups { get; set; } = Array.Empty<string>();

        [JsonProperty(nameof(IsArchived))]
        public bool IsArchived { get; set; } = false;

        [JsonProperty(nameof(IsDonor))]
        public bool IsDonor { get; set; } = false;

        [JsonProperty(nameof(IsEventAttendee))]
        public bool IsEventAttendee { get; set; } = false;

        [JsonProperty(nameof(IsMember))]
        public bool IsMember { get; set; } = false;

        [JsonProperty(nameof(MemberId))]
        public DateTimeOffset MemberId { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(MemberSince))]
        public DateTimeOffset MemberSince { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(Notes))]
        public string Notes { get; set; } = string.Empty;

        [JsonProperty(nameof(Phone))]
        public Phone Phone { get; set; } = new Phone();

        [JsonProperty(nameof(ReceiveEventReminders))]
        public bool ReceiveEventReminders { get; set; } = false;

        [JsonProperty(nameof(ReceiveNewsletters))]
        public DateTimeOffset ReceiveNewsletters { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(RecievingEMailsDisabled))]
        public bool RecievingEMailsDisabled { get; set; } = false;

        [JsonProperty(nameof(RenewalDue))]
        public DateTimeOffset RenewalDue { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(HasAcceptedPrivacyPolicy))]
        public bool HasAcceptedPrivacyPolicy { get; set; } = false;

        [JsonProperty(nameof(DateOfBirth))]
        public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(nameof(MarketPosition))]
        public string[] MarketPosition { get; set; } = Array.Empty<string>();

        [JsonProperty(nameof(HasAcceptedClubRules))]
        public bool HasAcceptedClubRules { get; set; } = false;
    }

    public partial class Phone
    {
        [JsonProperty("country")]
        public string Country { get; set; } = string.Empty;

        [JsonProperty("countryCallingCode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CountryCallingCode { get; set; } = 0;

        [JsonProperty("nationalNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NationalNumber { get; set; } = 0;

        [JsonProperty("number")]
        public string Number { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"+{CountryCallingCode} {NationalNumber}";
        }
    }

    public partial class MembershipLevel
    {
        [JsonProperty(nameof(Id))]
        public long Id { get; set; } = 0;

        [JsonProperty(nameof(Url))]
        public Uri Url { get; set; } = new Uri("about:blank");

        [JsonProperty(nameof(Name))]
        public string Name { get; set; } = string.Empty;
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
        public override bool CanConvert(type t) =>
            t == typeof(ValueUnion) || t == typeof(ValueUnion?);

        public override object? ReadJson(
            JsonReader reader,
            type t,
            object? existingValue,
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
                    return new ValueUnion { String = stringValue! };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PurpleValue>(reader);
                    return new ValueUnion { PurpleValue = objectValue! };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<ValueElement[]>(reader);
                    return new ValueUnion { ValueElementArray = arrayValue! };
            }
            throw new TypeInitializationException("Cannot unmarshal type ValueUnion", null);
        }

        public override void WriteJson(
            JsonWriter writer,
            object? untypedValue,
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
        public override bool CanConvert(type t) => t == typeof(long) || t == typeof(long?);

        public override object? ReadJson(
            JsonReader reader,
            type t,
            object? existingValue,
            JsonSerializer serializer
        )
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (long.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(
            JsonWriter writer,
            object? untypedValue,
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
