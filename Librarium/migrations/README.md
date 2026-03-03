### Requirement 1 — Books need authors
Supporting the authors, not onlly need to create the Authors table but alos to add the relation between books and authors, I have decided
to create another table where this relation will be mapped,where Book ISBN i ti s aforeign key referencing Books and AuthorId 
reference an author from Authors table , like this we achiev one to manny relation. 

### Requirement 2 — Email addresses must be unique, and the member profile is expanding

Providing support for the  unique Email, i have decided to add a sufix for the duplicated emails
"'_dup_' + CAST(MemberId AS VARCHAR(36))", thi will make the emails unique.
Than i have adde a new column called Isemailverified where i have marked the duplicates as "false",
so the users will be asked to confirm or create a new email.

To enforce the NONNULL on the PhoneNumber column, i have create the column first with null values, 
that i have added the "pending"  as phone number placeholder, and than modified the Phone number coumn to
Not allow nulls.