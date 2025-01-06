# 📦 Zamin Solution Package (📖 English Version)
## 🔰 Introduction 

If you are using the **Zamin architecture** ([Zamin](https://github.com/oroumand/Zamin)) for your project development, there are two critical requirements that are usually time-consuming and prone to errors:

1. Creating the overall structure of the project along with all required layers.
2. Creating Aggregates and implementing basic CRUD operations.

To address these needs, the **Zamin Solution Package** provides two templates to simplify and automate these tasks:

- **ZaminSln**:
  For creating the overall structure of the project along with all required layers  
- **ZaminAggCrud**:
  For creating Aggregates and basic CRUD operations across all layers   

## ⚙️ Package Installation

To install this package via NuGet, run the following command in the terminal:
```bash
dotnet new --install ZaminTemplatePackage
```
🔗 For more details, visit the [NuGet link](https://www.nuget.org/packages/Zamin.Solution.Templates).

## 🏗️ Creating the Overall Project Structure (ZaminSln)

### Command
```bash
dotnet new zaminsln --namespace ProjectNameSpace --dbcontext ProjectDbContextName
```

### Parameter Descriptions
- **namespace:**
  Specifies the main name of the Solution and all project layers. This name is used as a prefix for all related projects and folders.
- **dbcontext:**
  Specifies the name of the DbContext used in the Command and Query layers.

### Example
If the parameters are provided as follows:
- `namespace`: `MyProject`
- `dbcontext`: `MyDb`

The following structure will be created:
```
src
├── Core
│   ├── MyProject.Core.Resources
│   ├── MyProject.Core.Domain
│   ├── MyProject.Core.RequestResponse
│   ├── MyProject.Core.Contracts
│   └── MyProject.Core.ApplicationService
├── Infra
│   └── Data
│       ├── MyProject.Infra.Data.Sql.Commands
│       │   ├── MyDbCommandDbContext.cs
│       │   └── MyDbCommandDbContextFactory.cs
│       └── MyProject.Infra.Data.Sql.Queries
│           └── MyDbQueryDbContext.cs
└── Endpoints
    └── MyProject.Endpoints.API
```

## 🧩 Creating Aggregates and Basic CRUD Operations (ZaminAggCrud)

### Command
```bash
dotnet new zaminaggcrud --namespace ProjectNameSpace --dbcontext ProjectDbContextName --folder AggregateFolderName --aggregate AggregateName
```

### Parameter Descriptions
- **namespace:**
  Specifies the main name of the Solution and all project layers. This name is used as a prefix for all related projects and folders.
- **dbcontext:**
  Specifies the name of the DbContext used in the Command and Query layers.
- **folder:**
  Specifies the folder name where files related to the Aggregate will be placed in each layer.
- **aggregate:**
  Specifies the name of the Aggregate.

### Example
If the parameters are provided as follows:
- `namespace`: `MyProject`
- `dbcontext`: `MyDb`
- `folder`: `Blogs`
- `aggregate`: `Blog`

The following structure will be created:
```
src
├── Core
│   ├── MyProject.Core.Domain
│   │   ├── Blogs
│   │   │   ├── Entities
│   │   │   │   └── Blog.cs
│   │   │   ├── Parameters
│   │   │   │   ├── BlogCreateParameter.cs
│   │   │   │   └── BlogUpdateParameter.cs
│   │   │   └── Event
│   │   │       ├── BlogCreated.cs
│   │   │       ├── BlogUpdated.cs
│   │   │       └── BlogDeleted.cs
│   ├── MyProject.Core.RequestResponse
│   │   ├── Blogs
│   │   │   ├── Commands
│   │   │   │   ├── Create
│   │   │   │   │   └── BlogCreateCommand.cs
│   │   │   │   ├── Update
│   │   │   │   │   └── BlogUpdateCommand.cs
│   │   │   │   └── Delete
│   │   │   │       └── BlogDeleteCommand.cs
│   │   │   ├── Queries
│   │   │   │   ├── GetById
│   │   │   │   │   ├── BlogGetByIdQuery.cs
│   │   │   │   │   └── BlogQr.cs
│   │   │   │   ├── GetPagedFilter
│   │   │   │   │   ├── BlogGetPagedFilterQuery.cs
│   │   │   │   │   └── BlogListItemQr.cs
│   │   │   │   └── GetSelectList
│   │   │   │       ├── BlogGetSelectListQuery.cs
│   │   │   │       └── BlogSelectItemQr.cs
│   ├── MyProject.Core.Contracts
│   │   ├── Blogs
│   │   │   ├── Commands
│   │   │   │   └── IBlogCommandRepository.cs
│   │   │   ├── Queries
│   │   │       └── IBlogQueryRepository.cs
│   └── MyProject.Core.ApplicationService
│       ├── Blogs
│       │   ├── Commands
│       │   │   ├── Create
│       │   │   │   └── BlogCreateHandler.cs
│       │   │   ├── Update
│       │   │   │   └── BlogUpdateHandler.cs
│       │   │   └── Delete
│       │   │       └── BlogDeleteHandler.cs
│       │   ├── Queries
│       │   │   ├── GetById
│       │   │   │   └── BlogGetByIdHandler.cs
│       │   │   ├── GetPagedFilter
│       │   │   │   └── BlogGetPagedFilterHandler.cs
│       │   │   └── GetSelectList
│       │   │       └── BlogGetSelectListHandler.cs
├── Infra
│   └── Data
│       ├── MyProject.Infra.Data.Sql.Commands
│       │   ├── Blogs
│       │   │   ├── Configs
│       │   │   │   └── BlogConfig.cs
│       │   │   └── BlogCommandRepository.cs
│       └── MyProject.Infra.Data.Sql.Queries
│           ├── Blogs
│           │   └── BlogQueryRepository.cs
└── Endpoints
    ├── MyProject.Endpoints.API
        └── Blogs
            └── BlogController.cs
```

# 📦 Zamin Solution Package (📖 Persian Version)

## 🔰 معرفی 

اگر از **معماری Zamin** ([Zamin](https://github.com/oroumand/Zamin)) برای توسعه پروژه‌های خود استفاده می‌کنید، دو نیاز کلیدی وجود دارد که معمولاً زمان‌بر بوده و احتمال بروز خطا در انجام آن‌ها وجود دارد:

1. ایجاد ساختار کلی پروژه همراه با تمامی لایه‌های موردنیاز.
2. ایجاد Aggregates و پیاده‌سازی عملیات پایه CRUD.

برای رفع این نیازها، **بسته راهکار Zamin** دو قالب را برای ساده‌سازی و خودکارسازی این وظایف ارائه می‌دهد:

- **ZaminSln**:
  برای ایجاد ساختار کلی پروژه همراه با تمامی لایه‌های موردنیاز  
- **ZaminAggCrud**:
  برای ایجاد Aggregates و عملیات پایه CRUD در تمامی لایه‌ها  

## ⚙️ نصب بسته

برای نصب این بسته از طریق NuGet، دستور زیر را در خط فرمان اجرا کنید:
```bash
dotnet new --install ZaminTemplatePackage
```
🔗 برای مشاهده جزئیات بیشتر می‌توانید به [لینک NuGet](https://www.nuget.org/packages/Zamin.Solution.Templates) مراجعه کنید.

## 🏗️ ایجاد ساختار کلی پروژه و لایه‌ها (ZaminSln)

### دستور
```bash
dotnet new zaminsln --namespace ProjectNameSpace --dbcontext ProjectDbContextName
```

### توضیحات پارامترها
- **namespace:**
  مشخص‌کننده نام اصلی Solution و تمامی لایه‌های پروژه است. این نام به عنوان پیشوند تمامی پروژه‌ها و فولدرهای مربوطه استفاده می‌شود.
- **dbcontext:**
  مشخص‌کننده نام DbContext‌هایی است که در لایه‌های Command و Query استفاده می‌شوند.

### مثال
اگر پارامترها به صورت زیر وارد شوند:
- `namespace`: `MyProject`
- `dbcontext`: `MyDb`

ساختار زیر ایجاد خواهد شد:
```
src
├── Core
│   ├── MyProject.Core.Resources
│   ├── MyProject.Core.Domain
│   ├── MyProject.Core.RequestResponse
│   ├── MyProject.Core.Contracts
│   └── MyProject.Core.ApplicationService
├── Infra
│   └── Data
│       ├── MyProject.Infra.Data.Sql.Commands
│       │   ├── MyDbCommandDbContext.cs
│       │   └── MyDbCommandDbContextFactory.cs
│       └── MyProject.Infra.Data.Sql.Queries
│           └── MyDbQueryDbContext.cs
└── Endpoints
    └── MyProject.Endpoints.API
```

## 🧩 ایجاد Aggregates و عملیات پایه CRUD (ZaminAggCrud)

### دستور
```bash
dotnet new zaminaggcrud --namespace ProjectNameSpace --dbcontext ProjectDbContextName --folder AggregateFolderName --aggregate AggregateName
```

### توضیحات پارامترها
- **namespace:**
  مشخص‌کننده نام اصلی Solution و تمامی لایه‌های پروژه است. این نام به عنوان پیشوند تمامی پروژه‌ها و فولدرهای مربوطه استفاده می‌شود.
- **dbcontext:**
  مشخص‌کننده نام DbContext‌هایی است که در لایه‌های Command و Query استفاده می‌شوند.
- **folder:**
  نام فولدری که فایل‌های مربوط به Aggregate در هر لایه داخل آن قرار می‌گیرد.
- **aggregate:**
  نام Aggregate موردنظر.

### مثال
اگر پارامترها به صورت زیر وارد شوند:
- `namespace`: `MyProject`
- `dbcontext`: `MyDb`
- `folder`: `Blogs`
- `aggregate`: `Blog`

ساختار زیر ایجاد خواهد شد:
```
src
├── Core
│   ├── MyProject.Core.Domain
│   │   ├── Blogs
│   │   │   ├── Entities
│   │   │   │   └── Blog.cs
│   │   │   ├── Parameters
│   │   │   │   ├── BlogCreateParameter.cs
│   │   │   │   └── BlogUpdateParameter.cs
│   │   │   └── Event
│   │   │       ├── BlogCreated.cs
│   │   │       ├── BlogUpdated.cs
│   │   │       └── BlogDeleted.cs
│   ├── MyProject.Core.RequestResponse
│   │   ├── Blogs
│   │   │   ├── Commands
│   │   │   │   ├── Create
│   │   │   │   │   └── BlogCreateCommand.cs
│   │   │   │   ├── Update
│   │   │   │   │   └── BlogUpdateCommand.cs
│   │   │   │   └── Delete
│   │   │   │       └── BlogDeleteCommand.cs
│   │   │   ├── Queries
│   │   │   │   ├── GetById
│   │   │   │   │   ├── BlogGetByIdQuery.cs
│   │   │   │   │   └── BlogQr.cs
│   │   │   │   ├── GetPagedFilter
│   │   │   │   │   ├── BlogGetPagedFilterQuery.cs
│   │   │   │   │   └── BlogListItemQr.cs
│   │   │   │   └── GetSelectList
│   │   │   │       ├── BlogGetSelectListQuery.cs
│   │   │   │       └── BlogSelectItemQr.cs
│   ├── MyProject.Core.Contracts
│   │   ├── Blogs
│   │   │   ├── Commands
│   │   │   │   └── IBlogCommandRepository.cs
│   │   │   ├── Queries
│   │   │       └── IBlogQueryRepository.cs
│   └── MyProject.Core.ApplicationService
│       ├── Blogs
│       │   ├── Commands
│       │   │   ├── Create
│       │   │   │   └── BlogCreateHandler.cs
│       │   │   ├── Update
│       │   │   │   └── BlogUpdateHandler.cs
│       │   │   └── Delete
│       │   │       └── BlogDeleteHandler.cs
│       │   ├── Queries
│       │   │   ├── GetById
│       │   │   │   └── BlogGetByIdHandler.cs
│       │   │   ├── GetPagedFilter
│       │   │   │   └── BlogGetPagedFilterHandler.cs
│       │   │   └── GetSelectList
│       │   │       └── BlogGetSelectListHandler.cs
├── Infra
│   └── Data
│       ├── MyProject.Infra.Data.Sql.Commands
│       │   ├── Blogs
│       │   │   ├── Configs
│       │   │   │   └── BlogConfig.cs
│       │   │   └── BlogCommandRepository.cs
│       └── MyProject.Infra.Data.Sql.Queries
│           ├── Blogs
│           │   └── BlogQueryRepository.cs
└── Endpoints
    ├── MyProject.Endpoints.API
        └── Blogs
            └── BlogController.cs
```
