<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
</Query>

var ctx = new PrincipalContext(ContextType.Domain);
var user = UserPrincipal.FindByIdentity(ctx, "-username-");

if(user != null)
{
 // find the roles....
 var roles = user.GetAuthorizationGroups();
 // enumerate over them
 foreach (Principal p in roles)
 {
     //p.DistinguishedName.Dump();
     p.Name.Dump();
     //p.UserPrincipalName.Dump();
     //p.SamAccountName.Dump();
 }
 
}