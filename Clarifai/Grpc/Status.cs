// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/clarifai/api/status/status.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Clarifai.Api.Status {

  /// <summary>Holder for reflection information generated from proto/clarifai/api/status/status.proto</summary>
  public static partial class StatusReflection {

    #region Descriptor
    /// <summary>File descriptor for proto/clarifai/api/status/status.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static StatusReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiZwcm90by9jbGFyaWZhaS9hcGkvc3RhdHVzL3N0YXR1cy5wcm90bxITY2xh",
            "cmlmYWkuYXBpLnN0YXR1cxoocHJvdG8vY2xhcmlmYWkvYXV0aC91dGlsL2V4",
            "dGVuc2lvbi5wcm90bxorcHJvdG8vY2xhcmlmYWkvYXBpL3N0YXR1cy9zdGF0",
            "dXNfY29kZS5wcm90byLbAQoGU3RhdHVzEi0KBGNvZGUYASABKA4yHy5jbGFy",
            "aWZhaS5hcGkuc3RhdHVzLlN0YXR1c0NvZGUSEwoLZGVzY3JpcHRpb24YAiAB",
            "KAkSDwoHZGV0YWlscxgDIAEoCRIZCgtzdGFja190cmFjZRgEIAMoCUIEgJwn",
            "ARIZChFwZXJjZW50X2NvbXBsZXRlZBgFIAEoDRIWCg50aW1lX3JlbWFpbmlu",
            "ZxgGIAEoDRIOCgZyZXFfaWQYByABKAkSHgoQaW50ZXJuYWxfZGV0YWlscxgI",
            "IAEoCUIEgJwnASI7CgxCYXNlUmVzcG9uc2USKwoGc3RhdHVzGAEgASgLMhsu",
            "Y2xhcmlmYWkuYXBpLnN0YXR1cy5TdGF0dXNCZwocY29tLmNsYXJpZmFpLmdy",
            "cGMuYXBpLnN0YXR1c1ABWj5naXRodWIuY29tL0NsYXJpZmFpL2NsYXJpZmFp",
            "LWdvLWdycGMvcHJvdG8vY2xhcmlmYWkvYXBpL3N0YXR1c6ICBENBSVBiBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Clarifai.Auth.Util.ExtensionReflection.Descriptor, global::Clarifai.Api.Status.StatusCodeReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Clarifai.Api.Status.Status), global::Clarifai.Api.Status.Status.Parser, new[]{ "Code", "Description", "Details", "StackTrace", "PercentCompleted", "TimeRemaining", "ReqId", "InternalDetails" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Clarifai.Api.Status.BaseResponse), global::Clarifai.Api.Status.BaseResponse.Parser, new[]{ "Status" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Status : pb::IMessage<Status> {
    private static readonly pb::MessageParser<Status> _parser = new pb::MessageParser<Status>(() => new Status());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Status> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Clarifai.Api.Status.StatusReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Status() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Status(Status other) : this() {
      code_ = other.code_;
      description_ = other.description_;
      details_ = other.details_;
      stackTrace_ = other.stackTrace_.Clone();
      percentCompleted_ = other.percentCompleted_;
      timeRemaining_ = other.timeRemaining_;
      reqId_ = other.reqId_;
      internalDetails_ = other.internalDetails_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Status Clone() {
      return new Status(this);
    }

    /// <summary>Field number for the "code" field.</summary>
    public const int CodeFieldNumber = 1;
    private global::Clarifai.Api.Status.StatusCode code_ = global::Clarifai.Api.Status.StatusCode.Zero;
    /// <summary>
    /// Status code from internal codes.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Clarifai.Api.Status.StatusCode Code {
      get { return code_; }
      set {
        code_ = value;
      }
    }

    /// <summary>Field number for the "description" field.</summary>
    public const int DescriptionFieldNumber = 2;
    private string description_ = "";
    /// <summary>
    /// A longer description of the error.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Description {
      get { return description_; }
      set {
        description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "details" field.</summary>
    public const int DetailsFieldNumber = 3;
    private string details_ = "";
    /// <summary>
    /// More details of the given error.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Details {
      get { return details_; }
      set {
        details_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "stack_trace" field.</summary>
    public const int StackTraceFieldNumber = 4;
    private static readonly pb::FieldCodec<string> _repeated_stackTrace_codec
        = pb::FieldCodec.ForString(34);
    private readonly pbc::RepeatedField<string> stackTrace_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// For some environment we may return a stack trace to help debug
    /// any issues.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> StackTrace {
      get { return stackTrace_; }
    }

    /// <summary>Field number for the "percent_completed" field.</summary>
    public const int PercentCompletedFieldNumber = 5;
    private uint percentCompleted_;
    /// <summary>
    /// specifically for long running jobs
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint PercentCompleted {
      get { return percentCompleted_; }
      set {
        percentCompleted_ = value;
      }
    }

    /// <summary>Field number for the "time_remaining" field.</summary>
    public const int TimeRemainingFieldNumber = 6;
    private uint timeRemaining_;
    /// <summary>
    /// if status is pending, how much time is remaining (in seconds)
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint TimeRemaining {
      get { return timeRemaining_; }
      set {
        timeRemaining_ = value;
      }
    }

    /// <summary>Field number for the "req_id" field.</summary>
    public const int ReqIdFieldNumber = 7;
    private string reqId_ = "";
    /// <summary>
    /// If we want to return a request id in the base status field
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ReqId {
      get { return reqId_; }
      set {
        reqId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "internal_details" field.</summary>
    public const int InternalDetailsFieldNumber = 8;
    private string internalDetails_ = "";
    /// <summary>
    /// Internal Annotation (do not set in production, for internal Clarifai use only).
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string InternalDetails {
      get { return internalDetails_; }
      set {
        internalDetails_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Status);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Status other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Code != other.Code) return false;
      if (Description != other.Description) return false;
      if (Details != other.Details) return false;
      if(!stackTrace_.Equals(other.stackTrace_)) return false;
      if (PercentCompleted != other.PercentCompleted) return false;
      if (TimeRemaining != other.TimeRemaining) return false;
      if (ReqId != other.ReqId) return false;
      if (InternalDetails != other.InternalDetails) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Code != global::Clarifai.Api.Status.StatusCode.Zero) hash ^= Code.GetHashCode();
      if (Description.Length != 0) hash ^= Description.GetHashCode();
      if (Details.Length != 0) hash ^= Details.GetHashCode();
      hash ^= stackTrace_.GetHashCode();
      if (PercentCompleted != 0) hash ^= PercentCompleted.GetHashCode();
      if (TimeRemaining != 0) hash ^= TimeRemaining.GetHashCode();
      if (ReqId.Length != 0) hash ^= ReqId.GetHashCode();
      if (InternalDetails.Length != 0) hash ^= InternalDetails.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Code != global::Clarifai.Api.Status.StatusCode.Zero) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Code);
      }
      if (Description.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Description);
      }
      if (Details.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Details);
      }
      stackTrace_.WriteTo(output, _repeated_stackTrace_codec);
      if (PercentCompleted != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(PercentCompleted);
      }
      if (TimeRemaining != 0) {
        output.WriteRawTag(48);
        output.WriteUInt32(TimeRemaining);
      }
      if (ReqId.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(ReqId);
      }
      if (InternalDetails.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(InternalDetails);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Code != global::Clarifai.Api.Status.StatusCode.Zero) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Code);
      }
      if (Description.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
      }
      if (Details.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Details);
      }
      size += stackTrace_.CalculateSize(_repeated_stackTrace_codec);
      if (PercentCompleted != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(PercentCompleted);
      }
      if (TimeRemaining != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(TimeRemaining);
      }
      if (ReqId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ReqId);
      }
      if (InternalDetails.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(InternalDetails);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Status other) {
      if (other == null) {
        return;
      }
      if (other.Code != global::Clarifai.Api.Status.StatusCode.Zero) {
        Code = other.Code;
      }
      if (other.Description.Length != 0) {
        Description = other.Description;
      }
      if (other.Details.Length != 0) {
        Details = other.Details;
      }
      stackTrace_.Add(other.stackTrace_);
      if (other.PercentCompleted != 0) {
        PercentCompleted = other.PercentCompleted;
      }
      if (other.TimeRemaining != 0) {
        TimeRemaining = other.TimeRemaining;
      }
      if (other.ReqId.Length != 0) {
        ReqId = other.ReqId;
      }
      if (other.InternalDetails.Length != 0) {
        InternalDetails = other.InternalDetails;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Code = (global::Clarifai.Api.Status.StatusCode) input.ReadEnum();
            break;
          }
          case 18: {
            Description = input.ReadString();
            break;
          }
          case 26: {
            Details = input.ReadString();
            break;
          }
          case 34: {
            stackTrace_.AddEntriesFrom(input, _repeated_stackTrace_codec);
            break;
          }
          case 40: {
            PercentCompleted = input.ReadUInt32();
            break;
          }
          case 48: {
            TimeRemaining = input.ReadUInt32();
            break;
          }
          case 58: {
            ReqId = input.ReadString();
            break;
          }
          case 66: {
            InternalDetails = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Base message to return when there is a internal server error that
  /// is not caught elsewhere.
  /// </summary>
  public sealed partial class BaseResponse : pb::IMessage<BaseResponse> {
    private static readonly pb::MessageParser<BaseResponse> _parser = new pb::MessageParser<BaseResponse>(() => new BaseResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BaseResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Clarifai.Api.Status.StatusReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BaseResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BaseResponse(BaseResponse other) : this() {
      status_ = other.status_ != null ? other.status_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BaseResponse Clone() {
      return new BaseResponse(this);
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 1;
    private global::Clarifai.Api.Status.Status status_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Clarifai.Api.Status.Status Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BaseResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BaseResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Status, other.Status)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (status_ != null) hash ^= Status.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (status_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Status);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (status_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Status);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BaseResponse other) {
      if (other == null) {
        return;
      }
      if (other.status_ != null) {
        if (status_ == null) {
          Status = new global::Clarifai.Api.Status.Status();
        }
        Status.MergeFrom(other.Status);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (status_ == null) {
              Status = new global::Clarifai.Api.Status.Status();
            }
            input.ReadMessage(Status);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
