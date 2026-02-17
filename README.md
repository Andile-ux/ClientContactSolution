# Client & Contact Management System (ASP.NET Core MVC)

This project was built according to strict technical requirements focusing on:

- Clean code structure
- Proper SQL table design
- Input validation
- OOP principles
- MVC architecture
- Unique business rule implementation (Client Code Generator)

---

##  Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Bootstrap (UI layout)
- LINQ
- Data Annotations (Validation)



##  Features

###  Clients
- Create new client
- Auto-generate unique Client Code (e.g. `FNB001`, `PRO123`)
- View client list ordered by Name (Ascending)
- Display number of linked contacts
- Link / Unlink contacts
- Tabbed UI (General / Contacts)

###  Contacts
- Create new contact
- Email validation (format + uniqueness)
- View contacts ordered by Surname + Name
- Display number of linked clients
- Link / Unlink clients
- Tabbed UI (General / Clients)

---

##  Client Code Generation Logic

Client codes follow strict business rules:

- 6 characters total
- First 3 = alphabetical (uppercase)
- Last 3 = numeric, starting from 001
- Must be unique
- Not random — increments until unique

Examples:

| Client Name            | Generated Code |
|------------------------|--------------- |
| First National Bank    | FNB001         |
| Protea                 | PRO001         |
| IT                     | ITA001         |

If name has fewer than 3 letters, alphabet fills from A-Z.

---

##  Database Design

### Tables

- Clients
- Contacts
- ClientContacts (Many-to-Many junction table)

### Key Design Points

- Primary keys on all tables
- Composite key on ClientContacts
- Unique constraint on:
  - Client.ClientCode
  - Contact.Email
- Proper indexing through PK/Unique constraints

---

##  Architecture
ClientContactSolution/
│
├── Controllers/
├── Models/
├── Data/
├── Views/
└── README.md
