# Breeders API

## 🛠 Technologies
* **.NET 8**
* **ASP.NET Core Web API**
* **Entity Framework Core** (ORM)
* **SQLite** * **Swagger / OpenAPI**
* ## 🏗 Architecture (Clean Architecture)

The solution is divided into 4 isolated projects:

1.  **`Breeders.Domain`**
2.  **`Breeders.Application`**
3.  **`Breeders.Infrastructure`**
4.  **`Breeders.API`**

## 🚀 How to Run Locally

1.  **Clone the repository**
2.  **Navigate to the API folder:**
    ```bash
    cd src/Breeders.API
    ```
3.  **Update the database (apply migrations):**
    Thanks to the Seed Data, the database will automatically be populated with test data.
    ```bash
    dotnet ef database update --project ../Breeders.Infrastructure --startup-project .
    ```
4.  **Run the project:**
    ```bash
    dotnet run
    ```
5.  **Open Swagger:**
    Navigate in your browser to `http://localhost:<your_port>/swagger` (or just to the root address if a redirect is configured).

## 🧪 Test Data (Seed Data)

A test breeder and several litters have already been added to the database. Use these identifiers in Swagger (insert the breeder ID into the `X-Breeder-Id` header field):

* **Test Breeder (X-Breeder-Id):**
  `11111111-1111-1111-1111-111111111111`

* **Litter ID (Status: Approved):**
  `22222222-2222-2222-2222-222222222222`

* **Litter ID (Status: Draft):**
  `33333333-3333-3333-3333-333333333333`