var result = context.Users.FromSql($"SELECT * from Users WHERE email = '{userEmail}';").ToList();
