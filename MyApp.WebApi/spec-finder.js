var context = require.context('./Frontend/src', true, /.+\.spec\.tsx?$/);
context.keys().forEach(context);
