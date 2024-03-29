# GamesAPI

#### An example implementation of a small .NET games library Web API i developed for educational purposes.

It is not intended to be production ready or to be maintained apart from occasional bug fixing; **most of the features provided are not fully implemented, rather included as a demonstration on how they could be structured in a realistic scenario**.

If you want to take a look at the actual development stage, checkout the '**develop**' branch. 

Additional feature branches may be opened occasionally.

### Commits
#### Naming convention
Commit type must follow [standard naming convention](https://www.conventionalcommits.org/en/v1.0.0/#summary):

- **build**: Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
- **ci**: Changes to CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs)
- **docs**: Documentation only changes
- **feat**: A new feature
- **fix**: A bug fix
- **perf**: A code change that improves performance
- **refactor**: A code change that neither fixes a bug nor adds a feature
- **style**: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- **test**: Adding missing tests or correcting existing tests

## Features
- Bearer token based authentication system with numeric identities
- API Versioning
- Full-blown automatic exceptions handler for request scopes with Serilog logging
- Standardized response formats
- Dynamicly filterable GET queries
- Export data as documents (only Excel driver implemented)
- Upload / Download Files facade
- Compose / Send Mail facades for MailKit (Multiple recipients, attachments, Text/MimePart/HTML Template Body support with tokenization)

- Semantic file structure (Core layer/Application layer)
- Standardized SRP application layer (Controller -> Service -> Repository)
- Automatic DTOs mapping
- Custom policies examples

## Run Locally

Clone the project

```bash
  git clone https://github.com/sim1-dev/GamesAPI.git
```

Go to the project directory

```bash
  cd GamesAPI
```

Start the server

```bash
  dotnet run
```

## License

[MIT](https://choosealicense.com/licenses/mit/)

## Author

- [@sim1-dev](https://github.com/sim1-dev) - Simone Tenisci


## Buy [me](https://www.simonetenisci.net/) a coffee ☕

[![alt text][image]][hyperlink]

[hyperlink]:https://www.paypal.com/donate/?hosted_button_id=AS2MJZNHSQEQA
[image]:https://pics.paypal.com/00/s/NDI2ZTExZWQtODY4MS00ZTZiLTg4OGEtZjc1MmEyNjYwNzRj/file.PNG
(Donate with PayPal)
