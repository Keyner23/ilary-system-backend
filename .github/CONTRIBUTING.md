
Contributing Guidelines
Thank you for contributing to this project! Please take a moment to read through these guidelines before making changes.

## Branch Naming Convention
All branches must follow this format:

type/AZURE-CODE

### Examples:
- `feat/ILARY-101` ➜ New feature for Jira ticket BOA-101
-`fix/ILARY-202` ➜ Bug fix related to Jira ticket BOA-202
- `docs/ILARY-303` ➜ Documentation updates for Jira ticket BOA-303

## Commit Messages
We use Conventional Commits:

`<type>(scope?): <short description>`


### Examples:
- `feat(auth): add login endpoint`
- `fix(db): resolve duplicate primary key issue`
- `docs(readme): update setup instructions`


### 📌 Pull Requests
We use a Pull Request template to ensure consistency.
When you open a PR, GitHub will automatically load this template.


### Rules for Pull Requests
1. **Branch naming**: follow the convention `type/ILARY-CODE`  
   - Example: `feat/ILARY-101`, `fix/ILARY-202`.
2. **Keep PRs focused**: one PR = one clear change (avoid mixing unrelated updates).
3. **Commit messages**: must follow [Conventional Commits](https://www.conventionalcommits.org/).
4. **Update documentation** if your change affects usage or setup.
5. **Request a review**: at least one reviewer must approve before merging.

### PR Process
1. Create your branch from ` dev`.
2. Make your changes and commit them using the proper commit message format.
3. Push your branch to the repo.
4. Fill in all required sections (description, azure ticket, checklist, etc.).
5. Request a review and address feedback.
6. Once approved the PR can be merged.