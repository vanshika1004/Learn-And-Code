# Learn-And-Code
Repository for all Learn &amp; Code assignments.

# Coding Guidelines

## 1. Naming
- Use meaningful, readable, and intention-revealing names  
- Classes, Methods, Enums → PascalCase  
- Variables, Parameters → camelCase  
- Private fields → _camelCase  
- Constants → UPPER_SNAKE_CASE  
- Interfaces should be prefixed with I  
- Async methods must end with Async  
- Boolean variables should use prefixes such as Is, Has, or Can  
- Avoid ambiguous or generic names  

---

## 2. Methods
- Keep methods small and focused (recommended ≤ 20–25 lines)  
- A method should perform a single responsibility  
- Use clear and descriptive method names  
- Limit the number of parameters (prefer ≤ 3)  
- Use parameter objects when needed  
- Avoid deep nesting and complex logic  
- Follow DRY (Don't Repeat Yourself)  
- Follow Command–Query Separation  

---

## 3. Comments
- Prefer self-explanatory code over comments  
- Use comments only for intent, warnings, and TODOs  
- Avoid redundant or outdated comments  
- Do not leave commented-out code  

---

## 4. Formatting

### Vertical Formatting
- Separate logical sections with blank lines  
- Keep related code grouped together  
- Place higher-level methods before lower-level implementations  
- Maintain consistent file structure  

### Horizontal Formatting
- Keep line length ≤ 100–120 characters  
- Use consistent indentation (4 spaces)  
- Always use braces for control statements  
- Follow consistent spacing conventions  
- Remove trailing whitespace  

---

## 5. Classes
- One class per file  
- Each class should have a single responsibility  
- Maintain high cohesion and low coupling  
- Avoid large or complex classes  
- Follow member ordering:
  - Constants → Static Fields → Instance Fields → Constructors → Public Methods → Private Methods  

---

## 6. Interfaces and Abstractions
- Prefer interfaces over concrete implementations  
- Keep interfaces small and focused  
- Avoid forcing unused implementations  
- Depend on abstractions to reduce coupling  

---

## 7. Design Principles
- Follow SOLID principles  
- Design for extensibility and maintainability  
- Prefer composition over inheritance  
- Keep business logic separate from infrastructure and UI layers  

---

## 8. Error Handling
- Use structured exception handling  
- Never suppress or ignore exceptions  
- Provide meaningful error messages  
- Log exceptions with proper context  
- Validate inputs at application boundaries  
- Avoid using exceptions for control flow  

---

## 9. Asynchronous Programming
- Use async/await consistently  
- Avoid blocking calls  
- Handle exceptions properly in async methods  
- Avoid mixing synchronous and asynchronous patterns unnecessarily  

---

## 10. Dependency Management
- Use only necessary dependencies  
- Keep packages up to date  
- Avoid unnecessary third-party libraries  
- Prefer built-in .NET features where possible  

---

## 11. Avoid Bad Practices
- Avoid global or static state unless necessary  
- Avoid magic numbers; use constants or enums  
- Avoid hardcoded configuration values  
- Remove unused variables and imports  
- Avoid tight coupling between components  

---

## 12. Modular Design
- Follow layered architecture (API, Application, Domain, Infrastructure)  
- Break code into smaller, independent modules  
- Ensure low coupling and high cohesion  
- Clearly separate concerns  

---

## 13. Constants and Enums
- Use constants for fixed values  
- Use enums for related sets of values  
- Avoid hardcoded strings and numbers in logic  

---

## 14. Testing and Maintainability
- Write unit tests for business logic  
- Ensure critical components are well tested  
- Keep tests independent and reliable  
- Design code for testability  
- Avoid tightly coupled code  

---

## 15. Refactoring
- Continuously improve code quality  
- Refactor complex or unclear code  
- Follow the Boy Scout Rule: leave the code better than you found it  

---

## 16. Pull Request Guidelines
- Clearly define the problem statement  
- Provide a concise explanation of the solution  
- Keep pull requests focused on a single change  
- Ensure code is tested and reviewed before submission  
- Remove debug logs and unused code  

