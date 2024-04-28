using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace rosyLandApi.Entities;

public class User
{
  [Key]
  public int DbRowId{get;set;}
  public string Id{get;set;}
  public string FirstName{get;set;}
  public string LastName{get;set;}
  public string Email{get;set;}
  public string Contact{get;set;}
  public DateTime LastModifiedDateTime{get;set;}
  [ForeignKey("User")]
  public int LastModifiedBy{get;set;}
}