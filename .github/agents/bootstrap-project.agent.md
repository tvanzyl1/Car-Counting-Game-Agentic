
---
name: bootstrap-project
description: Scaffolds a runnable app from scratch using Visual Studio Copilot Agent mode.
tools: ["read", "write", "edit", "terminal"]
target: visual-studio
infer: false
---
# Bootstrap Project (Visual Studio Agent)

> **Before starting:** Open this repository folder in **Visual Studio 2026** (File → Open → Folder), open **Copilot Chat**, switch to **Agent** mode, and select the **bootstrap-project** agent from the agent dropdown.

## Variables (edit these inline before sending your first message)
- **ProjectName**: `CarCounter`
- **Template**: `webapp` | `mvc` | `worker` | `classlib`
- **Language**: `csharp` | `typescript` | `python`
- **Frontend**: `none` | `react` | `react-ts` | `blazor`
- **Database**: `none` | `sqlite` | `sqlserver`
- **TestFramework**: `xunit` | `nunit` | `mstest`
- **CI**: `github-actions` | `none`

---

You are an **autonomous coding agent** running inside **Visual Studio Agent mode**. Using the variables above, create a **new, runnable application** in this repository. Work iteratively until it **builds, tests pass, and the default run works**.

## Goals
1. **Solution & projects**
   - Create a solution named **{ProjectName}**.
   - If **Template = webapp**: create a minimal Web app.
   - If **Template = mvc**: create an MVC app with a `CarCounter` page. The user select three colour cars. Then the app counts the total number of cars and displays the result. Each time a user sees a car, there is a button to increment the counter for the colour car.
     - If **Frontend = react**: use React with JavaScript.
     - If **Frontend = react-ts**: use React with TypeScript.
     - If **Frontend = blazor**: use Blazor Server.
   - If **Template = worker**: create a background worker with structured logging and graceful shutdown.
   - If **Template = classlib**: create a class library with a sample service and unit tests.

2. **Language & structure**
   - **csharp**: .NET (latest LTS) SDK‑style projects.
   - **typescript**: Node + TypeScript; include `tsconfig.json`, ESLint, npm scripts. If **Frontend** is not `none`, place it under `/ui`.
   - **python**: FastAPI (API) or Typer (CLI); include `pyproject.toml`.

3. **Tests**
   - Create a test project under `/tests` using **TestFramework** with at least a health check test.

4. **Database (optional)**
   - **sqlite**: EF Core (C#) / Prisma (TS) / SQLModel (Py). Create initial migration + seed `Products`.
   - **sqlserver**: connection via env var; create initial migration.

5. **Developer experience**
   - Respect `.editorconfig`.
   - Provide `README.md` with prerequisites and **build/run/test** instructions.
   - Add launch profiles/tasks so **F5** works.

6. **CI (optional)**
   - If **CI = github-actions**, add `.github/workflows/ci.yml` to build & test on push/PR.

7. **Run & verify**
   - Build the solution, run tests, fix issues, retry as needed.
   - Start the app; verify `/health` (or equivalent) returns OK.
   - Output a summary of created files and next steps.

## Constraints
- Minimal, stable dependencies. Idiomatic structure. Ask for confirmation before running terminal commands.

## Deliverables
- New/updated files under `/src`, `/tests`, optional `.github/workflows`, and updated README.

**Begin by outlining your plan, then execute. If anything fails, diagnose and adapt until successful.**
