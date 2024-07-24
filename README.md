## PokemonReviewApp API Documentation

### Overview
- **Title**: PokemonReviewApp
- **Version**: 1.0

### Endpoints

#### Category

1. **Get All Categories**
   - **Endpoint**: `/api/Category`
   - **Method**: GET
   - **Description**: Retrieves a list of all categories.
   - **Responses**:
     - **200**: Success (returns an array of categories)

2. **Create a New Category**
   - **Endpoint**: `/api/Category`
   - **Method**: POST
   - **Description**: Creates a new category.
   - **Request Body**: Category details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **409**: Conflict (category already exists)
     - **500**: Server Error

3. **Get Category by ID**
   - **Endpoint**: `/api/Category/{categoryId}`
   - **Method**: GET
   - **Description**: Retrieves a category by its ID.
   - **Parameters**:
     - `categoryId` (required): ID of the category (integer)
   - **Responses**:
     - **200**: Success (returns the category)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (category not found)

4. **Update a Category by ID**
   - **Endpoint**: `/api/Category/{categoryId}`
   - **Method**: PUT
   - **Description**: Updates a category by its ID.
   - **Parameters**:
     - `categoryId` (required): ID of the category (integer)
   - **Request Body**: Updated category details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (category not found)
     - **500**: Server Error

5. **Delete a Category by ID**
   - **Endpoint**: `/api/Category/{categoryId}`
   - **Method**: DELETE
   - **Description**: Deletes a category by its ID.
   - **Parameters**:
     - `categoryId` (required): ID of the category (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (category not found)
     - **500**: Server Error

#### Country

1. **Get All Countries**
   - **Endpoint**: `/api/Country`
   - **Method**: GET
   - **Description**: Retrieves a list of all countries.
   - **Responses**:
     - **200**: Success (returns an array of countries)
     - **400**: Bad Request (invalid input)

2. **Create a New Country**
   - **Endpoint**: `/api/Country`
   - **Method**: POST
   - **Description**: Creates a new country.
   - **Request Body**: Country details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **409**: Conflict (country already exists)
     - **500**: Server Error

3. **Get Country by ID**
   - **Endpoint**: `/api/Country/{countryId}`
   - **Method**: GET
   - **Description**: Retrieves a country by its ID.
   - **Parameters**:
     - `countryId` (required): ID of the country (integer)
   - **Responses**:
     - **200**: Success (returns the country)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (country not found)

4. **Update a Country by ID**
   - **Endpoint**: `/api/Country/{countryId}`
   - **Method**: PUT
   - **Description**: Updates a country by its ID.
   - **Parameters**:
     - `countryId` (required): ID of the country (integer)
   - **Request Body**: Updated country details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (country not found)
     - **500**: Server Error

5. **Delete a Country by ID**
   - **Endpoint**: `/api/Country/{countryId}`
   - **Method**: DELETE
   - **Description**: Deletes a country by its ID.
   - **Parameters**:
     - `countryId` (required): ID of the country (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (country not found)
     - **500**: Server Error

6. **Get Owners by Country ID**
   - **Endpoint**: `/api/Country/{countryId}/owners`
   - **Method**: GET
   - **Description**: Retrieves all owners in a specified country.
   - **Parameters**:
     - `countryId` (required): ID of the country (integer)
   - **Responses**:
     - **200**: Success (returns an array of owners)
     - **400**: Bad Request (invalid input)

#### Owner

1. **Get All Owners**
   - **Endpoint**: `/api/Owner`
   - **Method**: GET
   - **Description**: Retrieves a list of all owners.
   - **Responses**:
     - **200**: Success (returns an array of owners)
     - **400**: Bad Request (invalid input)

2. **Create a New Owner**
   - **Endpoint**: `/api/Owner`
   - **Method**: POST
   - **Description**: Creates a new owner.
   - **Request Body**: Owner details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **409**: Conflict (owner already exists)
     - **500**: Server Error

3. **Get Owner by ID**
   - **Endpoint**: `/api/Owner/{ownerId}`
   - **Method**: GET
   - **Description**: Retrieves an owner by their ID.
   - **Parameters**:
     - `ownerId` (required): ID of the owner (integer)
   - **Responses**:
     - **200**: Success (returns the owner)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (owner not found)

4. **Update an Owner by ID**
   - **Endpoint**: `/api/Owner/{ownerId}`
   - **Method**: PUT
   - **Description**: Updates an owner by their ID.
   - **Parameters**:
     - `ownerId` (required): ID of the owner (integer)
   - **Request Body**: Updated owner details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (owner not found)
     - **500**: Server Error

5. **Delete an Owner by ID**
   - **Endpoint**: `/api/Owner/{ownerId}`
   - **Method**: DELETE
   - **Description**: Deletes an owner by their ID.
   - **Parameters**:
     - `ownerId` (required): ID of the owner (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (owner not found)
     - **500**: Server Error

6. **Get Pokemon by Owner ID**
   - **Endpoint**: `/api/Owner/{ownerId}/pokemon`
   - **Method**: GET
   - **Description**: Retrieves all Pokemon owned by a specified owner.
   - **Parameters**:
     - `ownerId` (required): ID of the owner (integer)
   - **Responses**:
     - **200**: Success (returns an array of Pokemon)
     - **400**: Bad Request (invalid input)

#### Pokemon

1. **Get All Pokemon**
   - **Endpoint**: `/api/Pokemon`
   - **Method**: GET
   - **Description**: Retrieves a list of all Pokemon.
   - **Responses**:
     - **200**: Success (returns an array of Pokemon)
     - **400**: Bad Request (invalid input)

2. **Create a New Pokemon**
   - **Endpoint**: `/api/Pokemon`
   - **Method**: POST
   - **Description**: Creates a new Pokemon.
   - **Request Body**: Pokemon details (JSON format)
   - **Parameters** (optional): 
     - `ownerId`: ID of the owner (integer)
     - `categoryId`: ID of the category (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **422**: Client Error (unprocessable entity)
     - **500**: Server Error



3. **Get Pokemon by ID**
   - **Endpoint**: `/api/Pokemon/{pokeId}`
   - **Method**: GET
   - **Description**: Retrieves a Pokemon by its ID.
   - **Parameters**:
     - `pokeId` (required): ID of the Pokemon (integer)
   - **Responses**:
     - **200**: Success (returns the Pokemon)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (Pokemon not found)

4. **Update a Pokemon by ID**
   - **Endpoint**: `/api/Pokemon/{pokeId}`
   - **Method**: PUT
   - **Description**: Updates a Pokemon by its ID.
   - **Parameters**:
     - `pokeId` (required): ID of the Pokemon (integer)
   - **Request Body**: Updated Pokemon details (JSON format)
   - **Parameters** (optional): 
     - `ownerId`: ID of the owner (integer)
     - `categoryId`: ID of the category (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (Pokemon not found)
     - **500**: Server Error

5. **Delete a Pokemon by ID**
   - **Endpoint**: `/api/Pokemon/{pokeId}`
   - **Method**: DELETE
   - **Description**: Deletes a Pokemon by its ID.
   - **Parameters**:
     - `pokeId` (required): ID of the Pokemon (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (Pokemon not found)
     - **500**: Server Error

6. **Get Pokemon Rating by ID**
   - **Endpoint**: `/api/Pokemon/{pokeId}/rating`
   - **Method**: GET
   - **Description**: Retrieves the rating of a Pokemon by its ID.
   - **Parameters**:
     - `pokeId` (required): ID of the Pokemon (integer)
   - **Responses**:
     - **200**: Success (returns the rating)
     - **400**: Bad Request (invalid input)

#### Review

1. **Get All Reviews**
   - **Endpoint**: `/api/Review`
   - **Method**: GET
   - **Description**: Retrieves a list of all reviews.
   - **Responses**:
     - **200**: Success (returns an array of reviews)

2. **Create a New Review**
   - **Endpoint**: `/api/Review`
   - **Method**: POST
   - **Description**: Creates a new review.
   - **Request Body**: Review details (JSON format)
   - **Parameters** (optional):
     - `pokeId`: ID of the Pokemon (integer)
     - `reviewerId`: ID of the reviewer (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **500**: Server Error

3. **Get Review by ID**
   - **Endpoint**: `/api/Review/{reviewId}`
   - **Method**: GET
   - **Description**: Retrieves a review by its ID.
   - **Parameters**:
     - `reviewId` (required): ID of the review (integer)
   - **Responses**:
     - **200**: Success (returns the review)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (review not found)

4. **Update a Review by ID**
   - **Endpoint**: `/api/Review/{reviewId}`
   - **Method**: PUT
   - **Description**: Updates a review by its ID.
   - **Parameters**:
     - `reviewId` (required): ID of the review (integer)
   - **Request Body**: Updated review details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (review not found)
     - **500**: Server Error

5. **Delete a Review by ID**
   - **Endpoint**: `/api/Review/{reviewId}`
   - **Method**: DELETE
   - **Description**: Deletes a review by its ID.
   - **Parameters**:
     - `reviewId` (required): ID of the review (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (review not found)
     - **500**: Server Error

6. **Get Reviews by Pokemon ID**
   - **Endpoint**: `/api/Review/pokemon/{pokeId}`
   - **Method**: GET
   - **Description**: Retrieves all reviews for a specified Pokemon.
   - **Parameters**:
     - `pokeId` (required): ID of the Pokemon (integer)
   - **Responses**:
     - **200**: Success (returns an array of reviews)
     - **400**: Bad Request (invalid input)

#### Reviewer

1. **Get All Reviewers**
   - **Endpoint**: `/api/Reviewer`
   - **Method**: GET
   - **Description**: Retrieves a list of all reviewers.
   - **Responses**:
     - **200**: Success (returns an array of reviewers)

2. **Create a New Reviewer**
   - **Endpoint**: `/api/Reviewer`
   - **Method**: POST
   - **Description**: Creates a new reviewer.
   - **Request Body**: Reviewer details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **409**: Conflict (reviewer already exists)
     - **500**: Server Error

3. **Get Reviewer by ID**
   - **Endpoint**: `/api/Reviewer/{reviewerId}`
   - **Method**: GET
   - **Description**: Retrieves a reviewer by their ID.
   - **Parameters**:
     - `reviewerId` (required): ID of the reviewer (integer)
   - **Responses**:
     - **200**: Success (returns the reviewer)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (reviewer not found)

4. **Update a Reviewer by ID**
   - **Endpoint**: `/api/Reviewer/{reviewerId}`
   - **Method**: PUT
   - **Description**: Updates a reviewer by their ID.
   - **Parameters**:
     - `reviewerId` (required): ID of the reviewer (integer)
   - **Request Body**: Updated reviewer details (JSON format)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (reviewer not found)
     - **500**: Server Error

5. **Delete a Reviewer by ID**
   - **Endpoint**: `/api/Reviewer/{reviewerId}`
   - **Method**: DELETE
   - **Description**: Deletes a reviewer by their ID.
   - **Parameters**:
     - `reviewerId` (required): ID of the reviewer (integer)
   - **Responses**:
     - **204**: No Content (success)
     - **400**: Bad Request (invalid input)
     - **404**: Not Found (reviewer not found)
     - **500**: Server Error

6. **Get Reviews by Reviewer ID**
   - **Endpoint**: `/api/Reviewer/{reviewerId}/reviews`
   - **Method**: GET
   - **Description**: Retrieves all reviews written by a specified reviewer.
   - **Parameters**:
     - `reviewerId` (required): ID of the reviewer (integer)
   - **Responses**:
     - **200**: Success (returns an array of reviews)
     - **400**: Bad Request (invalid input)

### Components (Schemas)

#### Category
- **Properties**:
  - `id` (integer)
  - `name` (string, nullable)
  - `pokemonCategories` (array, nullable)

#### CategoryDto
- **Properties**:
  - `id` (integer)
  - `name` (string, nullable)

#### Country
- **Properties**:
  - `id` (integer)
  - `name` (string, nullable)
  - `owners` (array, nullable)

#### CountryDto
- **Properties**:
  - `id` (integer)
  - `name` (string, nullable)

#### Owner
- **Properties**:
  - `id` (integer)
  - `firstName` (string, nullable)
  - `lastName` (string, nullable)
  - `gym` (string, nullable)
  - `country` (Country)
  - `pokemonOwners` (array, nullable)

#### OwnerDto
- **Properties**:
  - `id` (integer)
  - `firstName` (string, nullable)
  - `lastName` (string, nullable)
  - `gym` (string, nullable)

#### Pokemon
- **Properties**:
  - `id` (integer)
  - `name` (string, nullable)
  - `birthDate

` (string, date-time)
  - `reviews` (array, nullable)
  - `pokemonOwners` (array, nullable)
  - `pokemonCategories` (array, nullable)

#### PokemonCategory
- **Properties**:
  - `pokemonId` (integer)
  - `categoryId` (integer)
  - `pokemon` (Pokemon)
  - `category` (Category)

#### PokemonDto
- **Properties**:
  - `id` (integer)
  - `name` (string, nullable)
  - `birthDate` (string, date-time)

#### PokemonOwner
- **Properties**:
  - `pokemonId` (integer)
  - `ownerId` (integer)
  - `pokemon` (Pokemon)
  - `owner` (Owner)

#### ProblemDetails
- **Properties**:
  - `type` (string, nullable)
  - `title` (string, nullable)
  - `status` (integer, nullable)
  - `detail` (string, nullable)
  - `instance` (string, nullable)

#### Review
- **Properties**:
  - `id` (integer)
  - `title` (string, nullable)
  - `text` (string, nullable)
  - `rating` (integer)
  - `reviewer` (Reviewer)
  - `pokemon` (Pokemon)

#### ReviewDto
- **Properties**:
  - `id` (integer)
  - `title` (string, nullable)
  - `text` (string, nullable)
  - `rating` (integer)

#### Reviewer
- **Properties**:
  - `id` (integer)
  - `firstName` (string, nullable)
  - `lastName` (string, nullable)
  - `reviews` (array, nullable)

#### ReviewerDto
- **Properties**:
  - `id` (integer)
  - `firstName` (string, nullable)
  - `lastName` (string, nullable)
