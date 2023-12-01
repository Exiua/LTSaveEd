package LTSaveEd.Services;

import javafx.concurrent.Service;
import javafx.concurrent.Task;

public class FieldService extends Service<Void> {
    @Override
    protected Task<Void> createTask() {
        return new Task<>() {

            @Override
            protected Void call() throws Exception {

                for (int p = 0; p < 100; p++) {
                    Thread.sleep(40);
                    updateProgress(p, 100);
                }
                return null;
            }
        };
    }
}
